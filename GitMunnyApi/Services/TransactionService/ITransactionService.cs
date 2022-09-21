using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitMunnyApi.Dtos.Transactions;

namespace GitMunnyApi.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<ServiceResponse<List<GetTransactionDto>>> GetAllTransactions();
        Task<ServiceResponse<GetTransactionDto>> GetTransactionById(int id);
        Task<ServiceResponse<List<GetTransactionDto>>> AddTransaction(AddTransactionDto character);
        Task<ServiceResponse<GetTransactionDto>> UpdateTransaction(UpdateTransactionDto updatedTransaction);

    }
}