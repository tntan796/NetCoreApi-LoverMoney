using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Implements;
using BLL.Intefaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models;
using Newtonsoft.Json.Serialization;

namespace LoverMoney
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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddControllers();
            
            var userConnectionString = Configuration.GetConnectionString("LoverMoneyConnection");

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                            .AllowAnyMethod()
                                                             .AllowAnyHeader()));


            //JSOn serializer
            services.AddControllersWithViews().AddNewtonsoftJson(option =>
            option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                    .AddNewtonsoftJson(option => option.SerializerSettings.ContractResolver =
                    new DefaultContractResolver());

            //Register Repository
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IBankRepository, BankRepository>();
            services.AddTransient<IBudgetRepository, BudgetRespository>();
            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<IPackageRepository, PackageRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleDetailRepository, RoleDetailRepository>();
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IUserRepository, UserRepsitory>();
            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<IFaqRepository, FaqRepository>();

            // Register Service
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleDetailService, RoleDetailService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IFaqService, FaqService>();

            // Validate token gửi lên kèm api xem có đúng không
            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = issuer,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = System.TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Money Lover Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \t\n\r\n
                                    Enter 'Bearer' [space] and then your token in the text input below \r\n\r\n
                                    Example : 'Bearer 123456abc'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //Enable cors
            app.UseCors("AllowAll");

            app.UseAuthentication();

          
            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoverMoney Api");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
