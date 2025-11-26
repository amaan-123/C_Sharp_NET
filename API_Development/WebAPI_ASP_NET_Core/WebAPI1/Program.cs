using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Register the database context
// In ASP.NET Core, services such as the DB context must be registered with the 
// dependency injection (DI) container. The container provides the service to controllers.
builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
// The preceding code:

//Adds using directives.
//Adds the database context to the DI container.
//Specifies that the database context will use an in-memory database.

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

//my comment: app.----() is middleware
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
