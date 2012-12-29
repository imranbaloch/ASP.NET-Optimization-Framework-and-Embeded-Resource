using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace ImranB
{
    public class EmbeddedResourceHttpHandler : IHttpHandler
    {
        private RouteData _routeData;
        public EmbeddedResourceHttpHandler(RouteData routeData)
        {
            _routeData = routeData;
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var routeDataValues = _routeData.Values;
            var fileName = routeDataValues["file"].ToString();
            var fileExtension = routeDataValues["extension"].ToString();
            string nameSpace = typeof(EmbeddedResourceHttpHandler)
                                .Assembly
                                .GetName()
                                .Name;// Mostly the default namespace and assembly name are same
            string manifestResourceName = string.Format("{0}.{1}.{2}", nameSpace, fileName, fileExtension);
            var stream = typeof(EmbeddedResourceHttpHandler).Assembly.GetManifestResourceStream(manifestResourceName);
            context.Response.Clear();
            context.Response.ContentType = "text/css";// default
            if (fileExtension == "js")
                context.Response.ContentType = "text/javascript";
            stream.CopyTo(context.Response.OutputStream);
        }
    }
}
