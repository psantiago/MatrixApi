using System.Linq;
using System.Web.Http;
using MatrixApi.Domain;
using MatrixApi.Helpers;
using NHibernate.Linq;

namespace MatrixApi.Controllers
{
    public class CommentsController : ApiController
    {
        // POST api/comments
        public void Post([FromBody]Comment value)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                value.User = session.Query<User>().First(u => u.Email == User.Identity.Name);
                value.Ticket = session.Load<Ticket>(value.TicketId);
                session.Save(value);
            }
        }
    }
}
