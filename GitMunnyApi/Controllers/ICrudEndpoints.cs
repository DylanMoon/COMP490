using GitMunnyApi.Filters;

namespace GitMunnyApi.Controllers;

public interface ICrudEndpoints<T>
{
    Task<T?> Create(T newEntity);
    Task<T?> GetById(Guid id);
    Task<ICollection<T?>> GetAll( IEnumerable<IApiFilter<TransactionModel>> filters);
    Task<T?> Update(Guid id, T updatedEntity);
    Task<T?> Delete(Guid id, bool permanent);
}