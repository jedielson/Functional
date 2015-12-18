namespace Functional.Application.Interfaces.Common
{
    public interface ITransactionAppService
    {
        void BeginTransaction();
        void Commit();
    }
}
