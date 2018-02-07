using Owin;

namespace IISExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 注册中间件
            // app.Use<xxxxx>();

            app.Run(context =>
            {
                context.Response.ContentType = "text/palin";
                return context.Response.WriteAsync("Hello OWIN");
            });
        }
    }
}