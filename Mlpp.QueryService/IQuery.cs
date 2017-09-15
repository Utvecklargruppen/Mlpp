using Mlpp.Infrastructure.Storage.Mlpp;

namespace Mlpp.QueryService
{
    public interface IQuery<TResult>
    {
        TResult Execute(IReadOnlyMlppContext context);
    }
}
