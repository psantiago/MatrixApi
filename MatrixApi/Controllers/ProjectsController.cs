using System;
using System.Collections.Generic;
using System.Web.Http;
using MatrixApi.Domain;
using MatrixApi.Filters;

namespace MatrixApi.Controllers
{
    public class ProjectsController : ApiController
    {
        // GET api/values
        //[BaseAuthenticationFilter]
        public IEnumerable<string> Get()
        {
            var Project1 = new Project
                           {
                               Deadline = DateTime.Now.AddDays(7),
                               Description = "Further down the rabbit hole",
                               Id = 1,
                               Priority = Priority.Medium,
                               Status = Status.Pending,
                               Title = "The Blue Pill"
                           };

            var Project2 = new Project()
                           {
                               Deadline = DateTime.Now.AddHours(1),
                               Description = "Noodle baking",
                               Id = 2,
                               Priority = Priority.High,
                               Status = Status.InProgress,
                               Title = "There is no spoon"
                           };
            return new[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}
