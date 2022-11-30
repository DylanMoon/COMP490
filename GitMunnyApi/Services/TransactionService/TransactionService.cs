using AutoMapper;
using GitMunnyApi.Dtos.Transactions;
using GitMunnyApi.Filters;

namespace GitMunnyApi.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private static List<TransactionModel> Transactions { get; set; } = new List<TransactionModel>{};//replaced by the database
        private readonly IMapper _mapper;

        public TransactionService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<TransactionDto>>> GetTransaction(IEnumerable<IApiFilter<TransactionModel>> filters)
        {
            return new ServiceResponse<IEnumerable<TransactionDto>> {
            Data = Transactions.Where(model => filters.All(filter=> filter.Filter.Invoke(model))).Select(x => _mapper.Map<TransactionDto>(x)).ToList()
            };
        }
        
        public async Task<ServiceResponse<IEnumerable<TransactionDto>>> AddTransactions(IEnumerable<TransactionDto> transactions)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<TransactionDto>>()
            {
                Data = new List<TransactionDto>()
            };
            foreach (var transaction in transactions)
            {
                var current = _mapper.Map<TransactionModel>(transaction);
                var other = Transactions.FirstOrDefault(e => e.Id.Equals(current.Id));
                if (other is not null)
                {
                    ((List<TransactionDto>)serviceResponse.Data).Add(transaction);
                    continue;
                }
                Transactions.Add(current);
            }

            serviceResponse.Success = ((List<TransactionDto>) serviceResponse.Data).Count == 0;
            if (!serviceResponse.Success) serviceResponse.Message = "Unable to add all transactions";
            return serviceResponse;     
        } 

        public async Task<ServiceResponse<TransactionDto>> UpdateTransaction(Guid id, TransactionDto updatedTransaction)
        {
            var serviceResponse = new ServiceResponse<TransactionDto>();
            var transaction = Transactions.FirstOrDefault(x => x.Id.Equals(id));
            if (transaction is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Transaction not found";
                return serviceResponse;
            }
            transaction.Update(updatedTransaction);
            serviceResponse.Data = _mapper.Map<TransactionDto>(transaction);
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<TransactionDto>>> DeleteTransactions(IEnumerable<TransactionDto> transactions)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<TransactionDto>>
            {
                Data = new List<TransactionDto>()
            };
            foreach (var transaction in transactions)
            {
                var current = Transactions.FirstOrDefault(e => e.Id.Equals(transaction.Id));
                if (current is null)
                {
                    ((List<TransactionDto>) serviceResponse.Data).Add(transaction);
                    continue;
                }
                current.Deleted = true;
            }

            serviceResponse.Success = ((List<TransactionDto>) serviceResponse.Data).Count == 0;
            if (!serviceResponse.Success) serviceResponse.Message = "Unable to delete all transactions";
            return serviceResponse;
        }
    }
}