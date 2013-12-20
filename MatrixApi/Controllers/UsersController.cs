using System.Web.Http;
using MatrixApi.Domain;
using MatrixApi.Filters;
using MatrixApi.Helpers;

namespace MatrixApi.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/users/5
        [BasicAuthenticationFilter]
        public User Get(int id)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                var result = session.Get<User>(id);
                return result;
            }
        }
    }
}
