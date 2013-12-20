using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MatrixApi.Domain;

namespace MatrixApi.Controllers
{
    public class ProjectsController : ApiController
    {
        // GET api/projects
        //[BaseAuthenticationFilter]
        public IEnumerable<Project> Get()
        {
            var projects = FakeData.GetSomeProjects();
            return projects;
        }

        // GET api/projects/5
        public Project Get(int id)
        {
            var projects = FakeData.GetSomeProjects();
            return projects.First();
        }

        // GET api/projects/5/tickets
        [AcceptVerbs("GET", "POST")]
        [Route("api/projects/{id}/tickets")]
        public IEnumerable<Ticket> Tickets(int id)
        {
            var projects = FakeData.GetSomeProjects();
            var tickets = projects.First(p => p.Id == id).Tickets;
            return tickets;
        } 

        // POST api/projects
        public void Post([FromBody] string value)
        {
        }

        // PUT api/projects/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/projects/5
        public void Delete(int id)
        {
        }
    }
}