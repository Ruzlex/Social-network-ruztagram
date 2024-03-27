using ExampleCore.HttpLogic;
using ExampleCore.Logs;
using ExampleCore.TraceIdLogic;
using Serilog;
using Services;
using Infastracted;
using Microsoft.Extensions.ObjectPool;
using ProfileConnectionLib.ConnectionServices.RabbitConnectionServer;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseSerilog((hostingContext, loggerConfig) =>
{
    loggerConfig.GetConfiguration();
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpRequestService();
builder.Services.TryAddTraceId();
builder.Services.TryAddService();
builder.Services.TryAddInfastracted();
builder.Services.AddLoggerServices();
builder.Services.AddSingleton<ObjectPool<IConnection>>(serviceProvider =>
{
    return new DefaultObjectPool<IConnection>(new RabbitConnectionPool("localhost"), Environment.ProcessorCount * 2);
});
var app = builder.Build();

app.UseMiddleware<ReadTraceIdMiddlware>();
app.UseMiddleware<WriteTraceIdMiddlware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
