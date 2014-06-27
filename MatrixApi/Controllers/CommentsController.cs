﻿using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using MatrixApi.Domain;
using MatrixApi.Filters;
using MatrixApi.Helpers;
using NHibernate.Linq;

namespace MatrixApi.Controllers
{
    [EnableCors("*", "*", "*")]
    [BasicAuthenticationFilter] 
    public class CommentsController : ApiController
    {

        /// <summary>
        /// Adds a new comment to the server with form post to api/comments
        /// </summary>
        /// <param name="value">Comment data in the form post that conforms to api comment properties</param>
        public Comment Post([FromBody]Comment value)
        {
            value.CreatedAt = DateTime.Now;
            var session = NHibernateHelper.GetCurrentSession();
            value.User = session.Query<User>().First(u => u.Email == User.Identity.Name);
            value.Ticket = session.Load<Ticket>(value.TicketId);
            session.Save(value);
            session.Flush();
            return value;
        }
    }
}
