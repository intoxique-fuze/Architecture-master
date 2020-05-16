using DotNetCore.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Architecture.Web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder application)
        {
            application.UseException();
            application.UseCorsAllowAny();
            application.UseHttps();
            application.UseRouting();
            application.UseStaticFiles();
            application.UseResponseCompression();
            application.UseResponseCaching();
            application.UseAuthentication();
            application.UseAuthorization();
            application.UseEndpoints();

            //application.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";
            //    spa.UseAngularCliServer(npmScript: "start");
            //    spa.Options.StartupTimeout = TimeSpan.FromSeconds(200); // <-- add this line
            //});
            //application.UseSpa();
            application.UseSpa(spa =>
            {
                //spa.Options.SourcePath = "ClientApp";
                //spa.UseAngularCliServer(npmScript: "start");
                //spa.Options.StartupTimeout = TimeSpan.FromSeconds(200); // <-- add this line
                spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSecurity();
            services.AddResponseCompression();
            services.AddResponseCaching();
            services.AddControllersDefault();
            services.AddSpa();
            services.AddContext();
            services.AddServices();
        }
    }
}
