using System;
using System.Web;
using MatrixApi.Domain;
using MatrixApi.Helpers;
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

            new SchemaExport(cfg).Execute(true, false, false);
        }

        [Fact]
        public void CanInsertProject()
        {
            var session = NHibernateHelper.GetCurrentSession();

            var project = new Project { Title = "Test", Description = "test" };
            session.Save(project);
            
            NHibernateHelper.CloseSession();
        }

        [Fact]
        public void CanInsertTicket()
        {
            var session = NHibernateHelper.GetCurrentSession();

            var project = new Project { Title = "Test", Description = "test" };
            session.Save(project);
            var ticket = new Ticket { Project = project, Title = "Test Ticket", Description = "Test test" };
            session.Save(ticket);

            NHibernateHelper.CloseSession();
        }




        public void Dispose()
        {
            HttpContext.Current = null;

        }
    }
}