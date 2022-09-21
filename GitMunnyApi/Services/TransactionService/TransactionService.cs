using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GitMunnyApi.Dtos.Transactions;

namespace GitMunnyApi.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private static List<Transaction> _transactions { get; set; } = new List<Transaction>{};
        private readonly IMapper _mapper;

        public TransactionService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> GetAllTransactions()
        {
            return new ServiceResponse<List<GetTransactionDto>> {
            Data = _transactions.Where(x=> !x.Deleted).Select(x => _mapper.Map<GetTransactionDto>(x)).ToList()
            };
        }

        public async Task<ServiceResponse<GetTransactionDto>> GetTransactionById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTransactionDto>();
            var character = _transactions.FirstOrDefault(x=> x.Id == id);
            serviceResponse.Data = _mapper.Map<GetTransactionDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTransactionDto>>> AddTransaction(AddTransactionDto transaction)
        {
            var serviceResponse = new ServiceResponse<List<GetTransactionDto>>();
            _transactions.Add(_mapper.Map<Transaction>(transaction));
            serviceResponse.Data = _transactions.Where(x => !x.Deleted).Select(x =>_mapper.Map<GetTransactionDto>(x)).ToList();
            return serviceResponse;     
        }

        public async Task<ServiceResponse<GetTransactionDto>> UpdateTransaction(UpdateTransactionDto updatedTransaction)
        {
            var serviceResponse = new ServiceResponse<GetTransactionDto>();
            var transaction = _transactions.FirstOrDefault(x => x.Id == updatedTransaction.Id);
            if (transaction is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Transaction not found";
                return serviceResponse;
            }

            transaction.Amount = updatedTransaction.Amount;
            transaction.Note = updatedTransaction.Note;
            transaction.Vendor = updatedTransaction.Vendor;
            serviceResponse.Data = _mapper.Map<GetTransactionDto>(transaction);
            return serviceResponse;
        }
    }
}