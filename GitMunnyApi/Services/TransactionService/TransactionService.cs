using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GitMunnyApi.Dtos.Transactions;
using GitMunnyApi.Filters;

namespace GitMunnyApi.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private static List<TransactionModel> _transactions { get; set; } = new List<TransactionModel>{};//replaced by the database
        private readonly IMapper _mapper;

        public TransactionService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<TransactionDto>>> GetTransaction(IEnumerable<IApiFilter<TransactionModel>> filters)
        {
            return new ServiceResponse<IEnumerable<TransactionDto>> {
            Data = _transactions.Where(x=> !x.Deleted).Select(x => _mapper.Map<TransactionDto>(x)).ToList()
            };
        }
        
        public async Task<ServiceResponse<IEnumerable<TransactionDto>>> AddTransactions(IEnumerable<TransactionDto> transactions)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<TransactionDto>>();
            foreach (var transaction in transactions)
            {
                _transactions.Add(_mapper.Map<TransactionModel>(transaction));
            }
            
            serviceResponse.Data = _transactions.Where(x => !x.Deleted).Select(x =>_mapper.Map<TransactionDto>(x)).ToList();
            return serviceResponse;     
        } 

        public async Task<ServiceResponse<TransactionDto>> UpdateTransaction(TransactionDto updatedTransaction)
        {
            var serviceResponse = new ServiceResponse<TransactionDto>();
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
            serviceResponse.Data = _mapper.Map<TransactionDto>(transaction);
            return serviceResponse;
        }

        public Task<ServiceResponse<IEnumerable<TransactionDto>>> DeleteTransactions(IEnumerable<TransactionDto> transactions)
        {
            throw new NotImplementedException();
        }
    }
}