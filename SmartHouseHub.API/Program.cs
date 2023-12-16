using SmartHouseHub.API;
using System.Text.Json.Serialization;
using SmartHouseHub.API.Brokers.ZWave;
using SmartHouseHub.API.Helpers;
using SmartHouseHub.API.Interfaces;
using SmartHouseHub.API.Servises;
using SmartHouseHub.API.Brokers.ZWave.Commands;

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

// Logger
builder.Services.AddLogging(loggerSeq =>
    loggerSeq.AddSeq(builder.Configuration.GetSection("Seq")));

var mapper = MapperConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add service
builder.Services.AddTransient<IZWaveBrokerService, ZWaveBrokerService>();
builder.Services.AddTransient<IZWaveCommands, ZWaveCommands>();
builder.Services.AddTransient<IUserService, UserService>();

// Add Brokers
//TODO need to check if the port is free
builder.Services.AddSingleton<IZWaveBroker>(provider => new ZWaveBroker("COM3"));

// commands for broker
builder.Services.AddTransient<IZWaveCommands, ZWaveCommands>();

// Add database
builder.Services.AddSingleton<LiteDbHelper>();

// TODO: Move it 
//new CouchbaseLiteHelper().CreateReplicator(new()
//{
//    DbName = "db",
//    Password = "pass",
//    Username = "Edge1User",
//    Id = Guid.NewGuid(),
//});

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
