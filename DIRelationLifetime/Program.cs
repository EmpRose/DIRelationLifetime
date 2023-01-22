using DIRelationLifetime.Services;
using DIRelationLifetime.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton <ISingletonService, TestService>();   // Everytime on call the same address                   -lifetime 1: ever
builder.Services.AddSingleton<IScopedService, TestService>();       // Same address on call, until the end of a Service     -lifetime 1: for all dependencies(services) from a call
builder.Services.AddTransient<ITransientService, TestService>();    // new address for every call                           -lifetime 1: 1

builder.Services.AddTransient<DatabaseService>();                   // to proofe the lifetime                               -1: for all dependencies from a call


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
