using EAD_Ticket_Reservation_system.Models;
using EAD_Ticket_Reservation_system.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.Configure<DatabaseConnection>(
//    builder.Configuration.GetSection(nameof(DatabaseConnection)));

//builder.Services.AddSingleton<IDatabaseConnection>(sp => 
//sp.GetRequiredService<IOptions<IDatabaseConnection>>().Value);

//builder.Services.AddSingleton<IMongoClient>(s =>
//new MongoClient(builder.Configuration.GetValue<string>("DatabaseConnection:ConnectionString")));

//builder.Services.AddScoped<IClient, Client>();

builder.Services.Configure<DatabaseConnection>(
    builder.Configuration.GetSection("DatabaseConnection"));

// building the services
builder.Services.AddSingleton<Client>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
