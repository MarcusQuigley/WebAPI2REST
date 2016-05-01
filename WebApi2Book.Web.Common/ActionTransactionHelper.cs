using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
namespace WebApi2Book.Web.Common
{
    public class ActionTransactionHelper : IActionTransactionHelper
    {
        private readonly ISessionFactory sessionFactory;

        public ActionTransactionHelper(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public bool TransactionHandled { get; private set; }
        public bool SessionClosed { get; private set; }


        public void BeginTransaction()
        {
            if (!CurrentSessionContext.HasBind(sessionFactory)) return;
            
            var session = sessionFactory.GetCurrentSession();
            if (session != null)
            {
                session.BeginTransaction();
            }
        }

        public void EndTransaction(HttpActionExecutedContext filterContext)
        {
            if (!CurrentSessionContext.HasBind(sessionFactory)) return;

            var session = sessionFactory.GetCurrentSession();
            
            if (session == null) return;
             if (!session.Transaction.IsActive) return;
            
            if (filterContext.Exception == null)
            {
                session.Flush();
                session.Transaction.Commit();
            }
            else
            {
                session.Transaction.Rollback();
            }
            TransactionHandled = true;
        }

        public void CloseSession()
        {
            if (!CurrentSessionContext.HasBind(sessionFactory)) return;

            var session = sessionFactory.GetCurrentSession();
            session.Close();
            session.Dispose();
            CurrentSessionContext.Unbind(sessionFactory);
            SessionClosed = true;
        }
    }
}
