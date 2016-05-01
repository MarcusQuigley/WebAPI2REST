using System;
using System.Collections.Generic;
using log4net;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2Book.Common.Logging
{
    public class LogManagerAdapter : ILogManager
    {
        public ILog GetLog(Type typeAssociatedWithRequestLog)
        {
           var log= LogManager.GetLogger(typeAssociatedWithRequestLog);
           return log;
        }
    }
}
