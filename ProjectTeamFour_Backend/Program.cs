using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();
            //建置時立刻與資料庫連線
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var _context = service.GetRequiredService<CarCarPlanContext>();
                var _logger = service.GetRequiredService<ILogger<Program>>();

                try
                {
                    _context.Members.Any();
                    _logger.LogWarning("EF Core資料庫讀取成功");
                }
                catch (Exception ex)
                {
                    _logger.LogError(2003, ex.ToString());
                }

            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
