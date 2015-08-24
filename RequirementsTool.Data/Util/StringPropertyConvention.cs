using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Functional.Data.Nhibernate.SqlServer.Util
{
    public class StringPropertyConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Property.PropertyType == typeof(string))
                instance.CustomType("AnsiString");
        }
    }
}
