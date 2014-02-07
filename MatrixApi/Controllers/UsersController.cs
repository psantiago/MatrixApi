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
        /// <summary>
        /// Retrieve user with id = n using the url api/users/n from the database
        /// </summary>
        /// <returns>User</returns>
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
