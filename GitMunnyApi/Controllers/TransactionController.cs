using Microsoft.AspNetCore.Mvc;
using GitMunnyApi.Dtos.Transactions;
using GitMunnyApi.Filters;
using GitMunnyApi.Filters.TransactionFilters;
using GitMunnyApi.Services.TransactionService;

namespace GitMunnyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        
        [HttpGet()]
        public async Task<ActionResult<ServiceResponse<List<TransactionDto>>>> Get(
            [FromQuery] Guid? id,
            [FromQuery] DateTime? before,
            [FromQuery] DateTime? after,
            [FromQuery] double? greaterThan,
            [FromQuery] double? lessThan,
            [FromQuery] string? vendor,
            [FromQuery] IEnumerable<string>? tags)
        {
            var filters = new List<IApiFilter<TransactionModel>>();
            if(id is not null) filters.Add(new WithId(id.GetValueOrDefault()));
            if(before is not null) filters.Add(new Before(before.GetValueOrDefault()));
            if(after is not null) filters.Add(new After(after.GetValueOrDefault()));
            if(greaterThan is not null) filters.Add(new GreaterThan(greaterThan.GetValueOrDefault()));
            if(lessThan is not null) filters.Add(new LessThan(lessThan.GetValueOrDefault()));
            if(tags is not null) filters.Add(new IncludesTags(tags));
            return Ok(await _transactionService.GetTransaction(filters));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TransactionDto>>>> AddTransaction(
            [FromBody] TransactionDto newTransaction)
        {
            return Ok(await _transactionService.AddTransactions(new List<TransactionDto>(){newTransaction}));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<TransactionDto>>> UpdateTransaction(
            [FromRoute] Guid id,
            [FromBody]TransactionDto updatedTransaction)
        {
            return Ok(await _transactionService.UpdateTransaction(updatedTransaction));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TransactionDto>>>> DeleteTransactions(
            [FromBody] IEnumerable<TransactionDto> transactionsToBeDeleted)
        {
            return Ok(await _transactionService.DeleteTransactions(transactionsToBeDeleted));
        }

    }

}