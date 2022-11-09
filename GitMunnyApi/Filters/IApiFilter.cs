namespace GitMunnyApi.Filters;

public interface IApiFilter<in T>
{
    Func<T, bool> Filter { get; }

}