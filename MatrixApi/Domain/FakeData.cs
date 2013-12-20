using System;
using System.Collections.Generic;

namespace MatrixApi.Domain
{
    public static class FakeData
    {
        public static List<Project> GetSomeProjects()
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
            return new List<Project> { project1, project2 };
        }
    }
}