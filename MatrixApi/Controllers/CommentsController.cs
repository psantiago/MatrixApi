using System.Web.Http;
using MatrixApi.Domain;
using MatrixApi.Helpers;

namespace MatrixApi.Controllers
{
    public class CommentsController : ApiController
    {
        // POST api/comments
        public void Post([FromBody]Comment value)
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                session.Save(value);
            }
        }
    }
}
