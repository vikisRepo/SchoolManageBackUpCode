using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SMS.Models;
using SMSAPI.Authentication;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Middleware;
using WebApi.Services;

namespace SMS
{
	public class Startup
	{
		private readonly IWebHostEnvironment _env;
		private readonly IConfiguration _configuration;

		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
		public Startup(IWebHostEnvironment env, IConfiguration configuration)
		{
			_env = env;
			_configuration = configuration;
		}


		public void ConfigureServices(IServiceCollection services)
		{

			// use sql server db in production and sqlite db in development
			//if (_env.IsProduction())
			//	services.AddDbContext<DataContext>();
			//else
			//	services.AddDbContext<DataContext, SqliteDataContext>();

			// using System.Net;

			services.Configure<ForwardedHeadersOptions>(options =>
			{
				options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
			});


			services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
								  builder =>
								  {
									  builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod(); 
								  });
			});



			services.AddDbContext<MysqlDataContext>();
		//	services.AddCors();
			services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddSwaggerGen();

			// configure strongly typed settings object
			services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));

			services.AddControllersWithViews();
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			// configure strongly typed settings objects


			services.AddSwaggerGen(options => 
			{
				options.SwaggerDoc("v1",
					new Microsoft.OpenApi.Models.OpenApiInfo
					{
						Title = "Swagger SMS API",
						Description = "School Management System API",
						Version = "v1"
					});
			});

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});

			// configure DI for application services
			//services.AddScoped<IUserService, UserService>();


			// configure DI for application services
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IEmailService, EmailService>();
		
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MysqlDataContext dataContext)
		{
			// migrate any database changes on startup (includes initial db creation)
			dataContext.Database.Migrate();

			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();
			if (!env.IsDevelopment())
			{
				app.UseSpaStaticFiles();
			}

			app.UseRouting();
			app.UseCors(MyAllowSpecificOrigins);
			app.UseAuthentication();

			app.UseAuthorization();

			app.UseSwagger();

			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "School Swagger API");

			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});
		
			// global cors policy
			//app.UseCors(x => x
			//	.SetIsOriginAllowed(origin => true)
			//	.AllowAnyMethod()
			//	.AllowAnyHeader()
			//	.AllowCredentials());

			// global error handler
			app.UseMiddleware<ErrorHandlerMiddleware>();

			// custom jwt auth middleware
			app.UseMiddleware<JwtMiddleware>();

			app.UseEndpoints(x => x.MapControllers());
		
		}
	}
}
