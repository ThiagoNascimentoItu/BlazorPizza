using BlazorPizza.Server.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Mime;

namespace BlazorPizza.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();

            services.AddDbContext<PizzaStoreContext>(options => options.UseSqlite("Data Source=pizza.db"));

            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { MediaTypeNames.Application.Octet });
            });

        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //    })
        //        .AddCookie()
        //        .AddTwitter(twitterOptions =>
        //        {
        //            twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"];
        //            twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
        //            twitterOptions.Events.OnRemoteFailure = (context) =>
        //            {
        //                context.HandleResponse();
        //                return context.Response.WriteAsync("<script> windows.close(); </script>");
        //            };
        //        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseBlazor<Client.Startup>();
        }
    }
}
