using bmcdavid.BlogEngine.Core;
using bmcdavid.BlogEngine.FileRepository;
using bmcdavid.Web.Models;
using bmcdavid.Web.Models.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bmcdavid.Web
{
    // todo: find a descent responsive template
    // todo: Create markup/js needed using Gulp
    // todo: research if markdown taghelper can be fixed
    // todo: add search for blogs
    // todo: add rss for blogs

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // todo: register with DotNetStarter
            services.AddSingleton<IBlogRepository, BlogRepositoryFromFiles>();
            services.AddSingleton<IBlogPublicRepository, BlogPublicRepository>();
            services.AddSingleton<IBlogFileStore, BlogJsonFileStore>();
            services.AddSingleton<BlogRepositoryFilterForPublic>();
            services.AddSingleton<ITagRepository, TagRepository>();
            services.AddSingleton<Business.Services.SkillRepository>();

            services.AddScoped<ViewDependencies>();
            services.AddTransient<HomepageViewModel>();


            services.AddMvc(options =>
            {
                options.Filters.Add<Business.MvcFilters.LayoutFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseStaticFiles();
            app.UseBlogRewrite("/Blog/Article", new[] { "/", "/Home", "/Blog" });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "static",
                    template: "static/{*page}",
                    defaults: new { controller = "Static", action = "StaticContent" });
            });
        }
    }
}
