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
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TransactionDto>>>> Get(
            [FromQuery] Guid? id,
            [FromQuery] DateTime? before,
            [FromQuery] DateTime? after,
            [FromQuery] double? greaterThan,
            [FromQuery] double? lessThan,
            [FromQuery] TransactionType? type,
            [FromQuery] string? vendor,
            [FromQuery] IEnumerable<string>? tags,
            [FromQuery] bool? deleted = false)
        {
            var filters = new List<IApiFilter<TransactionModel>>();
            if(id is not null) filters.Add(new TransactionHasId(id.GetValueOrDefault()));
            if(before is not null) filters.Add(new TransactionBefore(before.GetValueOrDefault()));
            if(after is not null) filters.Add(new TransactionAfter(after.GetValueOrDefault()));
            if(greaterThan is not null) filters.Add(new TransactionGreaterThan(greaterThan.GetValueOrDefault()));
            if(lessThan is not null) filters.Add(new TransactionLessThan(lessThan.GetValueOrDefault()));
            if(type is not null) filters.Add(new TransactionIsType(type.GetValueOrDefault()));
            if (vendor is not null) filters.Add(new TransactionFromVendor(vendor));
            if(tags is not null) filters.Add(new TransactionIncludesTags(tags));
            if(deleted is null or false) filters.Add(new TransactionNotDeleted());
            return Ok(await _transactionService.GetTransaction(filters));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TransactionDto>>>> GetById([FromRoute] Guid id)
        {
            return Ok(await _transactionService.GetTransaction(new List<IApiFilter<TransactionModel>>(){new TransactionNotDeleted(), new TransactionHasId(id)}));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TransactionDto>>>> AddTransaction(
            [FromBody] IEnumerable<TransactionDto> newTransactions)
        {
            var response = await _transactionService.AddTransactions(newTransactions);
            if (response.Success is false) return UnprocessableEntity(response);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<TransactionDto>>> UpdateTransaction(
            [FromRoute] Guid id,
            [FromBody]TransactionDto updatedTransaction)
        {
            var response = await _transactionService.UpdateTransaction(id, updatedTransaction);
            if (response.Success is false) return NotFound(response);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TransactionDto>>>> DeleteTransactions(
            [FromBody] IEnumerable<TransactionDto>transactionsToBeDeleted)
        {
            var response = await _transactionService.DeleteTransactions(transactionsToBeDeleted);
            if (response.Success is false) return NotFound(response);
            return Ok(response); 
        }

    }

}