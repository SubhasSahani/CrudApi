using EngDesk.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// String? ConnectionString = builder.Configuration.GetConnectionString(BookStoreConnection)
// builder.Services.AddDbContext<EngineerDeskContext>(option => option.UseSqlServer(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));

var Provider = builder.Services.BuildServiceProvider();
var config = Provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<EngineerDeskContext>(item => item.UseSqlServer(config.GetConnectionString("BookStoreConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();
app.Run();

