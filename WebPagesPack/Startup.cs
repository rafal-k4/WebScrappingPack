using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HtmlParser.Interfaces;
using HtmlParser.Infrastructure;


namespace WebPagesPack
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<IKwejkHtmlParser, HtmlKwejkParser>();
            services.AddTransient<IKwejkRepository, KwejkRepository>();

            services.AddTransient<IJbzdyHtmlParser, HtmlJbzdyParser>();
            services.AddTransient<IJbzdyRepository, JbzdyRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage(); //this should not be added in deployed appilcations
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}", defaults: new { action = "Index" });
                routes.MapRoute(
                    name: "kwejk",
                    template: "{controller=Kwejk}/{id?}", defaults: new { action = "Index" });
                routes.MapRoute(
                    name: "jbzdy",
                    template: "{controller=Jbzdy}/{id?}", defaults: new { action = "Index" });

                
            });
        }
    }
}
