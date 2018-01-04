using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wbod.Models;
using Wbod.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Wbod.Infrastructure;

namespace Wbod
{
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
            services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordValidator>();
            services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();

            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
            services.AddDbContext<WbodContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, IdentityRole>(opts => {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<WbodContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "route6",
                    template: "Companies/AttachDirectorToNewCompany/Company/{CompanyId}/Director/{DirectorId}/Session/{SessionId}");
                routes.MapRoute(
                    name: "route5",
                    template: "Companies/AddDirectorToNewCompany/Company/{CompanyId}/Session/{SessionId}");
                routes.MapRoute(
                    name: "route4",
                    template: "Directorships/Records/Company/{Companyid}/Session/{Sessionid}");
                routes.MapRoute(
                    name: "route3",
                    template: "Directorships/AddDirector/Company/{Companyid}/Session/{Sessionid}/Director/{Directorid}");
                routes.MapRoute(
                    name: "route2",
                    template: "Directorships/AttachDirector/{Companyid}/Session/{Sessionid}");
                routes.MapRoute(
                    name: "route1",
                    template: "Directorships/Company/{Companyid}/Session/{Sessionid}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //May not be needed after first startup
            CreateRoles(serviceProvider);
        }

        //may not be needed after first startup. Taken from: https://stackoverflow.com/a/45219021
        private void CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            Task<IdentityResult> roleResult;
            //Check that there is an Administrator role and create if not
            Task<bool> hasDataEntryRole = roleManager.RoleExistsAsync("Data Entry");
            hasDataEntryRole.Wait();

            if (!hasDataEntryRole.Result)
            {
                roleResult = roleManager.CreateAsync(new IdentityRole("Data Entry"));
                roleResult.Wait();
            }

            Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Admin");
            hasAdminRole.Wait();

            if (!hasAdminRole.Result)
            {
                roleResult = roleManager.CreateAsync(new IdentityRole("Admin"));
                roleResult.Wait();
            }

        }
    }
}
