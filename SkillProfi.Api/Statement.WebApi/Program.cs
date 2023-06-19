using Statements.Application.Common;
using Statements.Application.Common.Dependenies;
using Statements.Application.Interfaces;
using Statements.Persistance;
using Statements.Persistance.Dependencies;
using Statements.WebApi.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

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
}

void Configure(WebApplication app)
{
	app.UseCustomExceptionHandler();
	app.UseRouting();
	app.UseHttpsRedirection();
	app.UseCors("AllowAll");

	app.UseEndpoints(endpoints => endpoints.MapControllers());
}