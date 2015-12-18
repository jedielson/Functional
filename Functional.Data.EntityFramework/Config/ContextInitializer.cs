namespace Functional.Data.Context.Config
{
    using System.Data.Entity;
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<FunctionalContext>
    {
        // ReSharper disable once RedundantOverridenMember
        protected override void Seed(FunctionalContext context)
        {
            base.Seed(context);
        }
    }
}
