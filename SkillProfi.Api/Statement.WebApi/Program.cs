using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;
using Serilog.Events;
using Statements.Application.Common;
using Statements.Application.Common.Dependenies;
using Statements.Application.Interfaces;
using Statements.Persistance;
using Statements.Persistance.Dependencies;
using Statements.WebApi.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

RegisterServices(builder.Services);

var app = builder.Build();
Log.Logger = new LoggerConfiguration().MinimumLevel.Override("Microsoft", LogEventLevel.Information)
	.WriteTo.File("StatementInfo-.txt", rollingInterval: RollingInterval.Day).CreateLogger();


using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
	try
	{
		var context = serviceProvider.GetRequiredService<StatementDbContext>();
		DbInitializer.Initialize(context);
	}
	catch (Exception exception)
	{
		Log.Fatal(exception, "An error occurred while app initialization");
	}
}

Configure(app);


app.Run();


void RegisterServices(IServiceCollection services)
{
	var provider = services.BuildServiceProvider();                    //
	var configuration = provider.GetRequiredService<IConfiguration>(); //Get IConfiguration

	services.AddAutoMapper(config =>
	{
		config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
		config.AddProfile(new AssemblyMappingProfile(typeof(IStatementDbContext).Assembly));
	});

	services.AddApplication();
	services.AddPersistance(configuration);
	services.AddControllers();

	services.AddCors(options => 
	{
		options.AddPolicy("AllowAll", policy => 
		{
			policy.AllowAnyHeader();
			policy.AllowAnyMethod(); //No restrictions
            policy.AllowAnyOrigin();
		});
	});

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
                {
                    config.Authority = "https://localhost:7277";
                    config.Audience = "api";
                });

    services.AddAuthorization();

    services.AddSwaggerGen();
	services.AddApiVersioning();
}

void Configure(WebApplication app)
{
	app.UseSwagger();
	app.UseSwaggerUI(config =>
	{
		config.RoutePrefix = string.Empty;
		config.SwaggerEndpoint("swagger/v1/swagger.json", "Statements API");
	});
	
	app.UseCustomExceptionHandler();
	app.UseRouting();
	app.UseHttpsRedirection();
	app.UseCors("AllowAll");
	app.UseApiVersioning();

	app.UseAuthentication();
	app.UseAuthorization();

	app.UseEndpoints(endpoints => endpoints.MapControllers());
}