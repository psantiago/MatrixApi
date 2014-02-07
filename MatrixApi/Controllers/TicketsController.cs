﻿using System.Linq;
using System.Web.Http;
using MatrixApi.Domain;
using MatrixApi.Helpers;
using NHibernate.Linq;

namespace MatrixApi.Controllers
{
    public class TicketsController : ApiController
    {

        /// <summary>
        /// Fetches a ticket, "n", from the server using url api/ticekts/n
        /// </summary>
        /// <param name="id">the ticket ID to fetch</param>
        /// <returns>A ticket</returns>
        public Ticket Get(int id)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                var result = session.Get<Ticket>(id);
                return result;
            }
        }

        /// <summary>
        /// Saves a new ticket to the database with form post to url api/tickets
        /// </summary>
        /// <param name="value">Ticket data in the form post that conforms to the api ticket structure</param>
        public void Post([FromBody]Ticket value)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                value.User = session.Query<User>().First(u => u.Email == User.Identity.Name);
                value.Project = session.Load<Project>(value.ProjectId);
                session.Save(value);
            }
        }

        /// <summary>
        /// Updates an existing ticket "n" in the database with a form post to api/tickets/n
        /// </summary>
        /// <param name="id">The ticket ID to update</param>
        /// <param name="value">Updated ticket in the form post</param>
        public void Put(int id, [FromBody]Ticket value)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                session.Update(value);
            }
        }
    }
}