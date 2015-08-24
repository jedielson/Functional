using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Functional.Data.Nhibernate.SqlServer.Util
{
    public class CustomForeignKeyConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Column(instance.Class.Name + "Id");
        }
    }
}
