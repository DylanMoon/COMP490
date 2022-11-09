using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitMunnyApi.Dtos.Transactions;
using GitMunnyApi.Filters;

namespace GitMunnyApi.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<ServiceResponse<IEnumerable<TransactionDto>>> GetTransaction(IEnumerable<IApiFilter<TransactionModel>> filters);
        Task<ServiceResponse<IEnumerable<TransactionDto>>> AddTransactions(IEnumerable<TransactionDto> transactions);
        Task<ServiceResponse<TransactionDto>> UpdateTransaction(TransactionDto updatedTransaction);

        Task<ServiceResponse<IEnumerable<TransactionDto>>> DeleteTransactions(IEnumerable<TransactionDto> transactions);

    }
}