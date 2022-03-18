namespace SUS.MvcFramework
{
    using SUS.HTTP;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port = 80)
        {
            List<Route> routeTable = new List<Route>();

            application.ConfigureServices();
            application.Configure(routeTable);

            var server = new HttpServer(routeTable);
           
           
            await  server.StartAsync(80);         
        }

    }
}
