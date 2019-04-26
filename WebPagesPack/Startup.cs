using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebPagesPack.Controllers.ControllersLogic;
using HtmlParser.Interfaces;
using WebPagesPack.Controllers;
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

            services.AddScoped<IHomeLogic, HomeLogic>();
            //services.AddScoped<IHtmlParser, Htm>();
            //services.AddScoped<IRepository, HtmlJbzdyRepository>();
            //services.AddScoped<KwejkController>(p=>new())
            //services.AddTransient(ctx =>
            //new HomeController(new TestService("Non-default value")));
            services.AddTransient(ctx =>
            new KwejkController());
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
                    template: "{controller=Home}/{action=Index}");
                routes.MapRoute(
                    name: "kwejk",
                    template: "{controller=Kwejk}/{action=Index}/{id?}");
            });
        }
    }
}
