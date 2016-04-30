using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi2Book.Web.Common.Routing
{
   public class ApiVersionRoutePrefixAttribute : RoutePrefixAttribute
    {
       private const string RouteBase = "api/{apiVersion:apiVersionConstraint(v1)}";
       private const string PrefixRouteBase = RouteBase + "/";

       public ApiVersionRoutePrefixAttribute(string prefix) 
       : base(string.IsNullOrEmpty(prefix)?RouteBase:(PrefixRouteBase+prefix)) { }

    }
}
