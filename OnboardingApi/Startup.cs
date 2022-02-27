using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OnboardingBusinessLogic;
using OnboardingInfrastructure;
using OnboardingInfrastructure.NewFolder;
using OnboardingRepository;
using OnboardingRepository.BaseRepo;
using OnboardingRepository.CustomerRepo;
using OnboardingRepository.OtpLogRepo;
using OnboardingUtilites;

namespace OnboardingApi
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
            services.AddControllers();
           
            services.AddScoped(typeof(IOtpSender), typeof(OtpSender)); 
            services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            services.AddScoped(typeof(IAlatService), typeof(AlatService)); 
            services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            services.AddScoped(typeof(IOtpLogRepository), typeof(OtpLogRepository));
            services.AddScoped(typeof(ICustomerInfoService), typeof(CustomerInfoService));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Onboarding Demo API", Version = "v1" });
            });

            string connStr = Configuration.GetConnectionString("OnboardingDbContext");

            services.AddDbContext<OnboardingDemoContext>(options =>
            {
                options.UseSqlServer(connStr);
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.Configure<AppSettings>(appSettingsSection);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
             
            app.UseSwagger();
 
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Onboarding Demo API");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
