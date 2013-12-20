using System.Web.Http;
using MatrixApi.Domain;
using MatrixApi.Helpers;

namespace MatrixApi.Controllers
{
    public class TicketsController : ApiController
    {
        // GET api/tickets/5
        public Ticket Get(int id)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                var result = session.Get<Ticket>(id);
                return result;
            }
        }

        // POST api/tickets
        public void Post([FromBody]Ticket value)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                session.Save(value);
            }
        }

        // PUT api/tickets/5
        public void Put(int id, [FromBody]Ticket value)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                session.Update(value);
            }
        }
    }
}