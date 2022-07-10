using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyAxiaMarket.Data;
using AutoMapper;
using MediatR;
using Newtonsoft.Json.Serialization;
using MyAxiaMarket1.Authentication.identityContext;
using MyAxiaMarket.Models;
using Microsoft.AspNetCore.Identity;
using MyAxiaMarket1.Settings;
using MyAxiaMarket1.DataAccess.Concrete;
using MyAxiaMarket1.DataAccess.Abstract;
using MyAxiaMarket1.DataAccess.Services.Concrete;
using MyAxiaMarket1.DataAccess.Services.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MyAxiaMarket
{
    public class Startup
    {
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();
            services.AddDbContext<AuthContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:AuthDbConnection"]));
            services.AddIdentity<Personne, IdentityRole>().AddEntityFrameworkStores<AuthContext>().AddDefaultTokenProviders();
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.Configure<JWTConfig>(Configuration.GetSection("JWTConfig"));
            services.AddCors(c =>
            {

                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddAuthorization(options => {

                options.AddPolicy("AdminPrivilege", policy => {
                    policy.RequireClaim("Role", "Admin");
                });
                options.AddPolicy("Client", policy => {
                    policy.RequireClaim("Role", "Client");
                });
                options.AddPolicy("Transporter", policy => {
                    policy.RequireClaim("Role", "Transporter");
                });
    
            });
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            )
            .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());
            
           
             services.AddControllers();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IBoutiqueRepository, BoutiqueRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICommandeRepository, CommandeRepository>();
            services.AddTransient<IContratRepository, ContratRepository>();
            services.AddTransient<IFactureRepository, FactureRepository>();
            services.AddTransient<IPanierRepository, PanierRepository>();
            services.AddTransient<IModeDePaiementRepository, ModeDePaiementRepository>();
            services.AddTransient<ICommentaireRepository, CommentaireRepository>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                var key = Encoding.ASCII.GetBytes(Configuration["JWTConfig:key"]);
                var issuer = Configuration["JWTConfig:Issuer"];
                var audience = Configuration["JWTConfig:Audience"];
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RequireExpirationTime = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience

                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AxiaMarket API", Version = "v1" });
            });
            //DependencyContainer.RegisterServices(services);

            //services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
           // services.AddMediatR(System.Reflection.Assembly.GetExecutingAssembly());
            services.AddControllers();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

          
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AxiaMarket  V1");
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthorization();



            //app.UseStaticFiles();

            //app.UseRouting();

           // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
