using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PharmacyMangement.DAL.Data;
using PharmacyManagement.DAL.DataAccess.Interface;
using PharmacyManagement.BAL.Services;
using PharmacyManagement.BAL.Contracts;
using PharmacyManagement.DAL.DataAccess;
using PharmacyManagement.BAL.Authentication;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace PharmacyManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public string JwtTokenBearerScheme { get; private set; }
        public string JwtBearerScheme { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

                services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PharmacyManagementDb"), b => b.MigrationsAssembly("PharmacyManagement.API"));

            });

            services.AddControllers();
            services.AddScoped<IDataAccess, DataAccess>();
            services.AddScoped<IAdminManager, AdminManager>();
            services.AddScoped<IFeedbackManager, FeedbackManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IMedicineManager, MedicineManager>();
            services.AddScoped<IRequestManager, RequestManager>();
            services.AddScoped<IJwtTokenManager, JwtTokenManager>();

            services.AddAuthentication(options =>

            {

                options.DefaultAuthenticateScheme = JwtBearerScheme;

                options.DefaultChallengeScheme = JwtBearerScheme;

            })

            .AddJwtBearer(options =>

            {

                options.RequireHttpsMetadata = false;

                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters

                {

                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:SecretKey"])),

                    ValidateIssuer = false,

                    ValidateAudience = false,

                    ClockSkew = TimeSpan.Zero

                };

            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PharmacyManagement", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PharmacyManagement v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
