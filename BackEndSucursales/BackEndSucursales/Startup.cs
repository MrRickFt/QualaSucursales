
using BackEndSucursales.Domain.IRepositories;
using BackEndSucursales.Domain.IServices;
using BackEndSucursales.Persistence.Context;
using BackEndSucursales.Persistence.Repositories;
using BackEndSucursales.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace BackEndSucursales
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public void ConfigureServices(IServiceCollection services)
        {
            //Conexión a SQL, el string conexion está en appsettings.Development.json
            services.AddDbContext<AplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("connection_db")));




            //Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IMonedaService, MonedaService>();
            services.AddScoped<ISucursalService, SucursalService>();

            //Repository
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ISucursalRepository, SucursalRepository>();
            services.AddScoped<IMonedaRepository, MonedaRepository>();

            //Cors configuración para comunicación de front con back
            services.AddCors(options => options.AddPolicy("AllowWebApp",
                                                            builder => builder.AllowAnyOrigin()
                                                                              .AllowAnyHeader()
                                                                              .AllowAnyMethod()));
            //Add Authentications
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"] ?? "defaultSecretKey")),
                        ClockSkew = TimeSpan.Zero


                    });


            //AddNewtonsonfjJson 
            services.AddControllers().AddNewtonsoftJson(options =>
                                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                            );
            services.AddEndpointsApiExplorer();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowWebApp");
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
