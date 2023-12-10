using System.Text.Json.Serialization;
using SmartHouseHub.API.Helpers;
using SmartHouseHub.API.Interfaces;
using SmartHouseHub.API.Servises;

// For dev
Environment.SetEnvironmentVariable("DATABASE_FILE", "SmartHouse.db");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Disable CORS
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add services
builder.Services.AddTransient<IInstanceService, InstanceService>();
builder.Services.AddTransient<ILogService, LogService>();

builder.Services.AddSingleton<LiteDbHelper>();

var app = builder.Build();

// Configure CORS policy
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
