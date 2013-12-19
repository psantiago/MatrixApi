using System.Web.Http.Controllers;

namespace MatrixApi.Filters
{
    public class BasicAuthenticationFilter : BaseAuthenticationFilter
    {

        public BasicAuthenticationFilter()
        { }

        public BasicAuthenticationFilter(bool active)
            : base(active)
        { }


        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            // TODO check the username and password against the database

            return true;
        }
    }
}