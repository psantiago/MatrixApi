using System;
using System.Collections;
using System.Web;
using MatrixApi.Domain;
using MatrixApi.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Xunit;

namespace MatrixApi.Tests.Tests
{
    public class Database : IDisposable
    {
        public Database()
        {
            HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null));
        }


        [Fact]
        public void CanGenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Project).Assembly);

            new SchemaExport(cfg).Execute(true, false, false);
        }

        [Fact]
        public void EverythingWorks()
        {
            var session = NHibernateHelper.GetCurrentSession();

            var tx = session.BeginTransaction();

            var project = new Project {Title = "Test", Description = "test"};
            session.Save(project);

            tx.Commit();

            NHibernateHelper.CloseSession();
        }


        public void Dispose()
        {
            HttpContext.Current = null;
        }
    }
}