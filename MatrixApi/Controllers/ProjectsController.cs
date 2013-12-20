using System.Collections.Generic;
using System.Web.Http;
using MatrixApi.Domain;
using MatrixApi.Helpers;

namespace MatrixApi.Controllers
{
    //[BasicAuthenticationFilter]
    /// <summary>
    /// This is a test
    /// </summary>
    public class ProjectsController : ApiController
    {
        // GET api/projects
        /// <summary>
        /// This is a tretstegwe
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> Get()
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                var result = session.CreateCriteria<Project>().List<Project>();
                return result;
            }

        }

        /// <summary>
        /// Test
        /// </summary>
        /// <param name="id">test</param>
        /// <returns>test</returns>
        public Project Get(int id)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                var result = session.Get<Project>(id);
                return result;
            }
        }

        // GET api/projects/5/tickets

        
        [AcceptVerbs("GET")]
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
        public void Post([FromBody]Project value)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                session.Save(value);
            }
        }

        // PUT api/projects/5
        public void Put(int id, [FromBody]Project value)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                session.Update(value);
            }
        }
    }
}