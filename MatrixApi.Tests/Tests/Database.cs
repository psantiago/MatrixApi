using MatrixApi.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Xunit;

namespace MatrixApi.Tests.Tests
{
    public class Database
    {
        [Fact]
        public void CanGenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Project).Assembly);

            new SchemaExport(cfg).Execute(true, false, false);
        }
    }
}