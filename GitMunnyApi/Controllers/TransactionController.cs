using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GitMunnyApi.Dtos.Transactions;
using GitMunnyApi.Filters;
using GitMunnyApi.Filters.TransactionFilters;

namespace GitMunnyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ICrudEndpoints<TransactionModel> _transactionService;
        private readonly Mapper _mapper;
        
        //TODO: use Mediator!

        public TransactionController(ICrudEndpoints<TransactionModel> transactionService, Mapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
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
            return Ok(await _transactionService.GetAll(filters));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TransactionDto>>>> GetById([FromRoute] Guid id)
        {
            return Ok(await _transactionService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TransactionDto>>> CreateTransaction(
            [FromBody] TransactionDto newTransaction)
        {
            var response = await _transactionService.Create(_mapper.Map<TransactionModel>(newTransaction));
            return response is not null ? Ok(_mapper.Map<TransactionDto>(response)) : UnprocessableEntity(newTransaction);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<TransactionDto>>> UpdateTransaction(
            [FromRoute] Guid id,
            [FromBody]TransactionDto updatedTransaction)
        {
            var response = await _transactionService.Update(id, _mapper.Map<TransactionModel>(updatedTransaction));
            return response is not null ? Ok(_mapper.Map<TransactionDto>(response)) : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ServiceResponse<TransactionDto>>> DeleteTransactions(
            [FromRoute] Guid id, [FromQuery] bool permanent)
        {
            var response = await _transactionService.Delete(id, permanent);
            return response is not null ? Ok(_mapper.Map<TransactionDto>(response)) : NotFound();
        }

    }

}