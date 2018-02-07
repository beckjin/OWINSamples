using Microsoft.Owin.Hosting;
using Owin;
using System;

namespace HttpListenerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 初始化StartOptions参数
            StartOptions options = new StartOptions();

            // 服务器Url设置
            options.Urls.Add("http://localhost:9000");
            options.Urls.Add("http://localhost:9001");
            options.ServerFactory = "Microsoft.Owin.Host.HttpListener";

            // 以Options和Startup启动Server
            using (WebApp.Start(options, Startup))
            {
                Console.WriteLine("Owin Host/Server started,press enter to exit it...");
                Console.ReadLine();
            }// Server在Dispose中关闭
        }

        private static void Startup(IAppBuilder app)
        {
            Console.WriteLine("Sample Middleware loaded...");
            // 注册中间件
            app.Use<SampleMiddleware>();
        }
    }
}
