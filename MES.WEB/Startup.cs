using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using MES.Web.Models;
using System.Globalization;
//using MES.BackgroundJob.Schedules;
//using Hangfire;
//using MES.Business;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using AutoMapper;
using MES.Web.AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
//using Hangfire.PostgreSql;

namespace MES.Web
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
            //services.AddControllersWithViews();
            //       .AddRazorRuntimeCompilation();
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
            
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Formatting = Formatting.None;
            }).AddJsonOptions(options=> options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Login/Index";
            });
            //services.AddMvc().AddNewtonsoftJson(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //});

            //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            //{
            //    Formatting = Formatting.None,
            //    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            //    PreserveReferencesHandling = PreserveReferencesHandling.Objects
            //};

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddMemoryCache();

            #region Dependencies
            //services.AddScoped<MenuLogic>();
            //services.AddScoped<UserTypeLogic>();
            //services.AddScoped<UserTypeMenuLogic>();
            //services.AddScoped<ExcellLogic>();
            //services.AddScoped<UserLogic>();
            //services.AddScoped<DepartmentLogic>();
            //services.AddScoped<UserTypeLogic>();
            //services.AddScoped<TitleLogic>();
            //services.AddScoped<LocationLogic>();
            //services.AddScoped<HoldingLogic>();
            //services.AddScoped<CompanyLogic>();
            //services.AddScoped<CityLogic>();
            //services.AddScoped<LdapInfoLogic>();
            #endregion

            // AutoMapper
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            
            var cultureInfo = new CultureInfo("tr-TR");
            //cultureInfo.NumberFormat.CurrencySymbol = "";

            app.UseSession();
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");
            }
            //app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Content")),
                RequestPath = new PathString("/Content")
            });
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    Authorization = new[] { new HangfireDashboardAuthorizationFilter() }
            //});
            //app.UseHangfireServer();

            //LdapInfoLogic ldapInfoLogic = new LdapInfoLogic();
            //var ldpmdl = ldapInfoLogic.Get();
            //RecurringJobs.MailSendingJob();
            //if (ldpmdl != null) RecurringJobs.LdapUpdateJob(ldpmdl?.CronType, ldpmdl.DailyTime, ldpmdl.DayOfWeek, ldpmdl.DayOfMonth, ldpmdl.OneTime);
        }
    }
}
