using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Tracing;
using System.Net.Http;
using log4net;
using WebApi2Book.Common.Logging;
namespace WebApi2Book.Web.Common
{
    public class SimpleTraceWriter : ITraceWriter
    {
        private readonly ILog log;

        public SimpleTraceWriter(ILogManager logManager)
        {
            log = logManager.GetLog(typeof(SimpleTraceWriter));
        }

        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            var rec = new TraceRecord(request, category, level);
            traceAction(rec);
            WriteTrace(rec);
        }





        public void WriteTrace(TraceRecord rec)
        {
            const string traceFormat = " RequestId={0};{1}Kind={2};{3}Status={4};{5}Operation={6};{7}Operator={8};{9} Category={10}{11}Request={12}{13}Message={14}";
            var args = new object[]
            {
                rec.RequestId,
                Environment.NewLine,
                rec.Kind,
                Environment.NewLine,
                rec.Status,
                Environment.NewLine,
                rec.Operation,
                Environment.NewLine,
                rec.Operator,
                Environment.NewLine,
                rec.Category,
                Environment.NewLine,
                rec.Request,
                Environment.NewLine,
                rec.Message
            };
            switch (rec.Level)
            {
                case TraceLevel.Debug:
                    log.DebugFormat(traceFormat, args);
                    break;
                case TraceLevel.Info:
                    log.InfoFormat(traceFormat, args);
                    break;
                case TraceLevel.Warn:
                    log.WarnFormat(traceFormat, args);
                    break;

                case TraceLevel.Error:
                    log.ErrorFormat(traceFormat, args);
                    break;
                case TraceLevel.Fatal:
                    log.FatalFormat(traceFormat, args);
                    break;
            }
        }
    }
}
