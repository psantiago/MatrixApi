using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MatrixApi.Domain;
using MatrixApi.Helpers;

namespace MatrixApi.Controllers
{
    //[BasicAuthenticationFilter]
    public class ProjectsController : ApiController
    {
        // GET api/projects
        public IEnumerable<Project> Get()
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                var result = session.CreateCriteria<Project>().List<Project>();
                return result;
            }

        }

        // GET api/projects/5
        public Project Get(int id)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                var result = session.Get<Project>(id);
                return result;
            }
        }

        // GET api/projects/5/tickets
        [AcceptVerbs("GET", "POST")]
        [Route("api/projects/{id}/tickets")]
        public IEnumerable<Ticket> Tickets(int id)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                var result = session.Get<Project>(id);
                return result.Tickets;
            }
        } 

        // POST api/projects
        public void Post([FromBody] string value)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                session.Save(value);
            }
        }

        // PUT api/projects/5
        public void Put(int id, [FromBody] string value)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                session.Update(value);
            }
        }
    }
}