global using saitynai_server.Entities;
global using saitynai_server.Repositories;
global using Microsoft.EntityFrameworkCore;
using saitynai_server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<TablegamesContext>();

builder.Services.AddTransient<IGamesRepository, GamesRepository>();
builder.Services.AddTransient<IAdvertisementsRepository, AdvertisementsRepository>();
builder.Services.AddTransient<ICommentsRepository, CommentsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
