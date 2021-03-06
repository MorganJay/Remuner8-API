using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using API.Core.Entities;
using API.Core.Interfaces;
using API.Infrastructure.Data.EntityFramework;
using API.Infrastructure.Data.Mapping;
using API.Infrastructure.Services;
using API.Infrastructure.Settings;
using API.Infrastructure.Data.EntityFramework.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Remuner8 API", Version = "v1" });
            });

            services.AddDbContext<Remuner8Context>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("Remuner8DB")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddEntityFrameworkStores<Remuner8Context>()
                .AddDefaultTokenProviders();
            ;
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            services.ConfigureApplicationCookie(Options =>
            {
                Options.LoginPath = "/Security/SignIn";
                Options.AccessDeniedPath = "/Security/AccessDenied";
                Options.ExpireTimeSpan = TimeSpan.FromSeconds(1500);
            });

            var key = Encoding.ASCII.GetBytes(Configuration["JwtSettings:Secret"]);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = false
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = true;
                jwt.SaveToken = true;
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddAutoMapper(typeof(MapperInitializer));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddControllersWithViews();

            services.AddScoped<IEmailSender, EmailSenderRepository>();
            services.AddScoped<IMailServiceRepository, MailServiceRepository>();
            services.AddScoped<IUserService, UserService>();

            // To be implemented in unit of work/generic repo/controller and then expunged
            services.AddScoped<IBonusRepository, BonusRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IJobDescriptionRepository, JobDescriptionRepository>();
            services.AddScoped<IPayrollCategoryRepository, PayrollCategoryRepository>();
            services.AddScoped<IPayrollDeductionRepository, PayrollDeductionRepository>();
            services.AddScoped<IPayrollDefaultRepository, PayrollDefaultRepository>();
            services.AddScoped<IPayrollItemsRepository, PayrollItemsRepository>();
            services.AddScoped<IPayrollOvertimeItemRepository, PayrollOvertimeItemRepository>();
            services.AddScoped<IPayrollRateRepository, PayrollRateRepository>();
            services.AddScoped<IPayslipRepository, PayslipRepo>();
            services.AddScoped<IRequestsRepository, RequestsRepository>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();

            // Enable CORS
            services.AddCors(options => options.AddPolicy("AllowEverthing", builder => builder.AllowAnyOrigin()
                                                                                              .AllowAnyMethod()
                                                                                              .AllowAnyHeader()));
            var sender = Configuration.GetSection("MailConfig")["SenderAddress"];
            var senderName = Configuration.GetSection("MailConfig")["SenderDisplayName"];

            var port = Convert.ToInt32(Configuration.GetSection("MailConfig")["Port"]);
            var password = Configuration.GetSection("MailConfig")["Password"];

            services.AddFluentEmail(sender, senderName)
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Remuner8 API v1"));
            }
            app.UseCors("AllowEverthing");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}