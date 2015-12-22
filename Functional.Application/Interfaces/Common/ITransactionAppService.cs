namespace Functional.Application.Interfaces.Common
{
    using Functional.Data.Context.Interfaces;

    public interface ITransactionAppService<TContext>
        where TContext : IDbContext, new()
    {
        void BeginTransaction();
        void Commit();
    }
}
