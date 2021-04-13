using API.Dtos;
using API.Models;
using API.Profiles;
using API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Remuner8_Backend.Repositories;
using System;
using System.Net;
using System.Net.Mail;

namespace API
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
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            services.AddDbContext<Remuner8Context>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddAutoMapper(typeof(AutomapperProfile));

            services.AddIdentity<ApplicationUser, IdentityRole>(

               )
                .AddEntityFrameworkStores<Remuner8Context>().AddDefaultTokenProviders();

            services.AddControllersWithViews();

            services.AddScoped<IUserAccountRepository, UserAccountsRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();
            services.AddScoped<IPayslipRepository, PayslipRepo>();
            services.AddScoped<IPayrollItemsRepository, PayrollItemsRepository>();
            services.AddScoped<IPayrollDeductionRepository, PayrollDeductionRepository>();
            services.AddScoped<IPayrollOvertimeItemRepository, PayrollOvertimeItemRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IEmailSender,EmailSenderRepository>();

            // Enable CORS
            services.AddCors(options => options.AddPolicy("AllowEverthing", builder => builder.AllowAnyOrigin()
                                                                                              .AllowAnyMethod()
                                                                                              .AllowAnyHeader()));
            var sender = Configuration.GetSection("MailConfig")["senderAddress"];
            var senderName = Configuration.GetSection("MailConfig")["senderDisplayName"];
           
            var port = Convert.ToInt32(Configuration.GetSection("MailConfig")["Port"]);
            var password = Configuration.GetSection("MailConfig")["Password"];

            services
                .AddFluentEmail(sender, senderName)
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient("smtp.gmail.com")
                {
                    Port = port,
                  
                    Credentials = new NetworkCredential(sender, password),
                    EnableSsl = true,
                    UseDefaultCredentials = false

                });
            //services.AddMvc(option =>
            //{
            //    var authorizationPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            //    option.Filters.Add(new AuthorizeFilter(authorizationPolicy));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
            app.UseCors("AllowEverthing");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}