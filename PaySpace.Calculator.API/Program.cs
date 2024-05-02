using Mapster;
using PaySpace.Calculator.Infrastructure.DataAccess;
using PaySpace.Calculator.Infrastructure.Repositories.Implementations;
using PaySpace.Calculator.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMapster();
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddCalculatorServices();
builder.Services.AddDataServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.InitializeDatabase();

app.Run();