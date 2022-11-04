global using saitynai_server.Entities;
global using saitynai_server.Repositories;
global using Microsoft.EntityFrameworkCore;
using saitynai_server.Data;
using Microsoft.AspNetCore.Identity;
using saitynai_server.Auth.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using saitynai_server.Auth;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using saitynai_server.Helpers;

//migrationBuilder.Sql("SET default_storage_engine=INNODB");
//migrationBuilder.Sql("SET GLOBAL innodb_default_row_format=DYNAMIC");

var builder = WebApplication.CreateBuilder(args);
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddIdentity<User, IdentityRole>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireUppercase = false;
    o.Password.RequireNonAlphanumeric = false;
    o.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<TablegamesContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters.ValidAudience = builder.Configuration["JWT:ValidAudience"];
        options.TokenValidationParameters.ValidIssuer = builder.Configuration["JWT:ValidIssuer"];
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]));
    });

builder.Services.AddDbContext<TablegamesContext>();

builder.Services.AddTransient<IGamesRepository, GamesRepository>();
builder.Services.AddTransient<IAdvertisementsRepository, AdvertisementsRepository>();
builder.Services.AddTransient<ICommentsRepository, CommentsRepository>();
builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<AuthDbSeeder>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PolicyNames.ResourceOwner, policy => policy.Requirements.Add(new ResourceOwnerRequirement()));
});

builder.Services.AddSingleton<IAuthorizationHandler, ResourceOwnerAuthorizationHandler>();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<TablegamesContext>();
dbContext.Database.Migrate();

var dbSeeder = scope.ServiceProvider.GetRequiredService<AuthDbSeeder>();
await dbSeeder.SeedAsync();

app.Run();
