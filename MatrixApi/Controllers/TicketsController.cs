using System.Web.Http;
using MatrixApi.Domain;
using MatrixApi.Helpers;

namespace MatrixApi.Controllers
{
    public class TicketsController : ApiController
    {
        // GET api/<controller>/5
        public Ticket Get(int id)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                var result = session.Get<Ticket>(id);
                return result;
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            // TODO
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            // TODO
        }
    }
}