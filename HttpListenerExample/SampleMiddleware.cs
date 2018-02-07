using Microsoft.Owin;
using System;
using System.Threading.Tasks;

namespace HttpListenerExample
{
    public class SampleMiddleware: OwinMiddleware
    {
        public SampleMiddleware(OwinMiddleware next)
            : base(next)
        {

        }

        public override Task Invoke(IOwinContext context)
        {
            PathString tickPath = new PathString("/tick");
            if (context.Request.Path.StartsWithSegments(tickPath))
            {
                string content = DateTime.Now.Ticks.ToString();
                context.Response.ContentType = "text/plain";
                context.Response.ContentLength = content.Length;
                context.Response.StatusCode = 200;
                context.Response.Expires = DateTimeOffset.Now;
                context.Response.Write(content);
                return Task.FromResult(0);
            }
            return Next.Invoke(context);
        }
    }
}
