using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using portfolio_dotnet_background.Models;

namespace portfolio_dotnet_background
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            EmailServerConfiguration config = new EmailServerConfiguration
            {
                SmtpPassword = Variables._smtpPassword,
                SmtpServer = Variables._smtpServer,
                SmtpUsername = Variables._smtpUsername
            };

            EmailAdress FromEmailAddress = new EmailAdress
            {
                Adress = Variables._emailClient,
                Name = Variables._clientName
            };

            services.AddSingleton<EmailServerConfiguration>(config);
            services.AddTransient<IEmailService, MailKitEmailService>();
            services.AddSingleton<EmailAdress>(FromEmailAddress);
            services.AddMvc();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "defaul",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}