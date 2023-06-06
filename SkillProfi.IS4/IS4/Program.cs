using IS4;
using IS4.Entities;
using IS4.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<AuthorizeDbContext>();
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

    services.AddControllers();
    string connectionString = configuration.GetValue<string>("DbConnection");

    services.AddDbContext<AuthorizeDbContext>(options =>
    {
        options.UseSqlite(connectionString);
    });

    services.AddIdentity<AppUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 6;
    }).AddEntityFrameworkStores<AuthorizeDbContext>().
       AddDefaultTokenProviders();

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
        AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
        {
            config.Audience = "api";
        });

    services.AddAuthorization();

    services.AddIdentityServer().
        AddDeveloperSigningCredential().
        AddInMemoryClients(Configuration.GetClients()).
        AddInMemoryApiScopes(Configuration.GetApiScopes()).
        AddInMemoryApiResources(Configuration.GetApiResources()).
        AddInMemoryIdentityResources(Configuration.GetIdentityResources()).
        AddAspNetIdentity<AppUser>();

    services.ConfigureApplicationCookie(config =>
    {
        config.Cookie.Name = "Statement.Identity.Cookie";
        config.LogoutPath = "/Account/Logout";
        config.LoginPath = "/Account/Login";
    });

    services.AddMvc(options => options.EnableEndpointRouting = false);
}

void Configure(WebApplication app)
{
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseIdentityServer();
    app.UseMvc();

    app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
}
