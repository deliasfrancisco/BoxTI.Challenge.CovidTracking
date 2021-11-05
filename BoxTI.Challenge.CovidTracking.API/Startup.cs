using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using BoxTI.Challenge.CovidTracking.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BoxTI.Challenge.CovidTracking.Models.Identity;

namespace BoxTI.Challenge.CovidTracking.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<BoxTIContext>(
				x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
				b => b.MigrationsAssembly("BoxTI.Challenge.CovidTracking.Data"))
				.EnableSensitiveDataLogging());

			IdentityBuilder builder = services.AddIdentityCore<User>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 4;
			});

			builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
			builder.AddEntityFrameworkStores<BoxTIContext>(); // informando que leva em consideração o contexto
			builder.AddRoleValidator<RoleValidator<Role>>();
			builder.AddRoleManager<RoleManager<Role>>();
			builder.AddSignInManager<SignInManager<User>>();

			services.AddMvc(options =>
			{
				var policy = new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.Build();
				options.Filters.Add(new AuthorizeFilter(policy));// Controla a politica de acesso
			})
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true, // Valida pela assinatura da chave do emissor 
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});

			services.AddCors();
			services.AddAutoMapper();
			services.AddControllers();
			services.AddSwaggerConfiguration();
			services.RegisterDependencies(Configuration);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors(x => x
			.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader()); //Permitindo a conexão remota de toda origem, todo metodo e todo cabeçalho

			app.UseHttpsRedirection();
			app.UseSwaggerConfiguration();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "BoxTI");
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			// Informa que o sistema tem que ser autenticado
			app.UseAuthentication();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});
		}
	}
}
