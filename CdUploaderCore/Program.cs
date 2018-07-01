using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CdUploaderCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseHttpSys(x => x.MaxRequestBodySize = null)
                .UseKestrel(x => x.Limits.MaxRequestBodySize = null);
    }
}
