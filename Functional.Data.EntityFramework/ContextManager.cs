namespace Functional.Data.Context
{
    using System.Web;
    using Interfaces;

    public class ContextManager<TContext> : IContextManager<TContext>
        where TContext : IDbContext, new()
    {
        private readonly string _contextKey;

        public ContextManager()
        {
            this._contextKey = "ContextKey." + typeof(TContext).Name;
        }

        public IDbContext GetContext()
        {

            if (HttpContext.Current.Items[this._contextKey] == null)
                HttpContext.Current.Items[this._contextKey] = new TContext();
            return HttpContext.Current.Items[this._contextKey] as IDbContext;
        }

        public void Finish()
        {
            if (HttpContext.Current.Items[this._contextKey] != null)
            {
                (HttpContext.Current.Items[this._contextKey] as IDbContext)?.Dispose();
            }
        }
    }
}
