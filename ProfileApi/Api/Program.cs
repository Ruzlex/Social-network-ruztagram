using ExampleCore.TraceIdLogic;
using Microsoft.Extensions.ObjectPool;
using ProfileConnectionLib.ConnectionServices.RabbitConnectionServer;
using ProfileDal;
using ProfileLogic;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.TryAddTraceId();
builder.Services.TryAddLogic();
builder.Services.TryAddDal();
builder.Services.AddSingleton<ObjectPool<IConnection>>(serviceProvider =>
{
    return new DefaultObjectPool<IConnection>(new RabbitConnectionPool("localhost"), Environment.ProcessorCount * 2);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

