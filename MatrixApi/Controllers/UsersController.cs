using System.Linq;
using System.Web.Http;
using MatrixApi.Domain;
using MatrixApi.Filters;
using MatrixApi.Helpers;
using NHibernate.Linq;

namespace MatrixApi.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/users/5
        [BasicAuthenticationFilter]
        public User Get()
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                var result = session.Query<User>().FirstOrDefault(u => u.Email == User.Identity.Name);
                return result;
            }
        }
    }
}
