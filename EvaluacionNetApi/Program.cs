using EvaluacionNet.Bussines.Calculo;
using EvaluacionNet.Bussines.interfaces.Calculo;
using EvaluacionNet.Repository.Calculo;
using EvaluacionNet.Repository.interfaces.Calculo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ICalculoBussines, CalculoBussines>();
builder.Services.AddTransient<ICalculoRepository, CalculoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
