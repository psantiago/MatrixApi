using System.Web;
using NHibernate;
using NHibernate.Cfg;
using StackExchange.Profiling;

namespace MatrixApi.Helpers
{
    public sealed class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";

        public static ISessionFactory SessionFactory { private get; set; }
        
        public static ISession GetCurrentSession()
        {
            var profiler = MiniProfiler.Current;

            using (profiler.Step("Get session inner"))
            {
                var context = HttpContext.Current;
                var currentSession = context.Items[CurrentSessionKey] as ISession;

                if (currentSession == null)
                {
                    currentSession = SessionFactory.OpenSession();
                    context.Items[CurrentSessionKey] = currentSession;
                }

                return currentSession;
            }
        }

        public static void CloseSession()
        {
            var context = HttpContext.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                // No current session
                return;
            }

            currentSession.Close();
            context.Items.Remove(CurrentSessionKey);
        }

        public static void CloseSessionFactory()
        {
            if (SessionFactory != null)
            {
                SessionFactory.Close();
            }
        }
    }
}