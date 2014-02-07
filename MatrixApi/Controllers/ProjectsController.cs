using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MatrixApi.Domain;
using MatrixApi.Helpers;
using NHibernate.Linq;
using StackExchange.Profiling;

namespace MatrixApi.Controllers
{
    //[BasicAuthenticationFilter]
    /// <summary>
    /// This is a test
    /// </summary>
    public class ProjectsController : ApiController
    {

        /// <summary>
        /// Fetches all projects with url api/projects
        /// </summary>
        /// <returns>A list of projects</returns>
        public IEnumerable<Project> Get()
        {
            var profiler = MiniProfiler.Current;

            var session = default (NHibernate.ISession);
            using (profiler.Step("Get session"))
            {
                session = NHibernateHelper.GetCurrentSession();
            }
            var result = default(IQueryable<Project>);
            using (profiler.Step("Get data"))
            {
                result = session.Query<Project>()
                    .FetchMany(p => p.Tickets);
                return result;
            }
        }

        /// <summary>
        /// Fetches specified project "n" using url /api/Get/n
        /// </summary>
        /// <param name="id">The id of the project to fetch</param>
        /// <returns>A Project</returns>
        public Project Get(int id)
        {
            var session = NHibernateHelper.GetCurrentSession();
            var result = session.Get<Project>(id);
            return result;
        }

        /// <summary>
        /// Fetch the ticekts that belong to a specified project "n" using url /api/projects/n/tickets
        /// </summary>
        /// <param name="id">The project id to which the tickets belong</param>
        /// <returns>A list of Tickets</returns>
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

        /// <summary>
        /// Adds a project to the database with form post to url api/projects
        /// </summary>
        /// <param name="value">Project data in the form post that conforms to api project properties</param>
        public void Post([FromBody]Project value)
        {
            var session = NHibernateHelper.GetCurrentSession();
            session.Save(value);
        }

        // PUT api/projects/5
        /// <summary>
        /// Updates an existing project ("n") in the databas with a form post to api/projects/n, where "n" is the id parameter of the project to update
        /// </summary>
        /// <param name="id">The project ID to update</param>
        /// <param name="value">The updated project to save</param>
        public void Put(int id, [FromBody]Project value)
        {
            var session = NHibernateHelper.GetCurrentSession();
            session.Update(value);
        }
    }
}