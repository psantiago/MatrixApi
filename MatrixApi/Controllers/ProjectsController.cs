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
        public IEnumerable<Project> Get()
        {
            var project1 = new Project
                           {
                               Deadline = DateTime.Now.AddDays(7),
                               Description = "Further down the rabbit hole",
                               Id = 1,
                               Priority = Priority.Medium,
                               Status = Status.Pending,
                               Title = "The Blue Pill",
                               Tickets = new List<Ticket>
                                         {
                                             new Ticket
                                             {
                                                 Deadline = DateTime.Now.AddDays(6),
                                                 Description = "Some ticket",
                                                 Id = 1,
                                                 Priority = Priority.Low,
                                                 Status = Status.InProgress,
                                                 Title = "Ticket the first",
                                                 User = new User
                                                        {
                                                            Email = "neo@thematrix.net",
                                                            Id = 7,
                                                            Name = "Neo",
                                                            Password = "Neo"
                                                        },
                                                 Comments = new List<Comment>
                                                            {
                                                                new Comment
                                                                {
                                                                    Body = "Here's a comment body",
                                                                    CreatedAt = DateTime.Now,
                                                                    User = new User()
                                                                           {
                                                                               Email = "neo@thematrix.net",
                                                                               Id = 7,
                                                                               Name = "Neo",
                                                                               Password = "Neo"
                                                                           }
                                                                }
                                                            }
                                             }
                                         }
                           };

            var project2 = new Project()
                           {
                               Deadline = DateTime.Now.AddHours(1),
                               Description = "Noodle baking",
                               Id = 2,
                               Priority = Priority.High,
                               Status = Status.InProgress,
                               Title = "There is no spoon",
                               Tickets = new List<Ticket>
                                         {
                                             new Ticket
                                             {
                                                 Deadline = DateTime.Now.AddDays(6),
                                                 Description = "Another Ticket, for the spoons",
                                                 Id = 1,
                                                 Priority = Priority.Low,
                                                 Status = Status.InProgress,
                                                 Title = "This is a ticket title",
                                                 User = new User
                                                        {
                                                            Email = "morpheus@thematrix.net",
                                                            Id = 7,
                                                            Name = "Morpheus",
                                                            Password = "Neo"
                                                        },
                                                 Comments = new List<Comment>
                                                            {
                                                                new Comment
                                                                {
                                                                    Body = "Neo says this project is dumb",
                                                                    CreatedAt = DateTime.Now,
                                                                    User = new User()
                                                                           {
                                                                               Email = "neo@thematrix.net",
                                                                               Id = 7,
                                                                               Name = "Neo",
                                                                               Password = "Neo"
                                                                           }
                                                                }
                                                            }
                                             }
                                         }

                           };
            return new[] {project1, project2};
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}