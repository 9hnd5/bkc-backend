using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bkc_backend.Controller.Helpers;
using bkc_backend.Data;
using bkc_backend.Services;
using bkc_backend.Services.AuthServices;
using bkc_backend.Services.EmployeeServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace bkc_backend.Api
{

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; set; }
        public Startup()
        {

            var builder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://localhost:3000", "http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
                                  });
            });
            services.AddDbContext<BkcDbContext>(options => options.UseSqlServer(Configuration["ConnectionString"]));
            //services.AddDbContext<BkcDbContext>(options => options.UseSqlServer("Server=.; Database=HRAD;User Id=sa;password=123456"));
            //services.AddDbContext<BkcDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
            services.AddControllers();
            services.AddScoped<IUserRoleServices, UserRoleServices>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<ICreateToken, CreateToken>();
            services.AddScoped<IUserRoleServices, UserRoleServices>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IBookerServices, BookerServices>();
            services.AddScoped<IBookingDetailServices, BookingDetailServices>();
            services.AddScoped<IBookingInforServices, BookingInforServices>();
            services.AddScoped<IDriverCarServices, DriverCarServices>();
            services.AddScoped<ICarServices, CarServices>();
            var key = Encoding.UTF8.GetBytes(Configuration["Key"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
