using Microsoft.EntityFrameworkCore;
using SLCM.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure DbContext
builder.Services.AddDbContext<SLCM.Data.AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// register repositories as scoped
builder.Services.AddScoped<SLCM.Repositories.IStudentRepository, SLCM.Repositories.StudentRepository>();
builder.Services.AddScoped<SLCM.Repositories.ICourseRepository, SLCM.Repositories.CourseRepository>();

//// Register repositories (for in-memory case)
//builder.Services.AddSingleton<SLCM.Repositories.IStudentRepository, SLCM.Repositories.StudentRepository>();
//builder.Services.AddSingleton<SLCM.Repositories.ICourseRepository, SLCM.Repositories.CourseRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalFrontend", policy =>
    {
        policy
          .WithOrigins("http://localhost:5173")   // Vite dev server origin
          .AllowAnyHeader()
          .AllowAnyMethod();
        // .AllowCredentials(); // only if you need cookies/auth
    });
});


var app = builder.Build();

//to seed data once initially if not present
//later on checked & ignored
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    // optional: catch and log any exceptions during seeding
    try
    {
        await Seeder.SeedAsync(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
        throw; // or decide to continue without seeding
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// enable CORS for the app (use the named policy)
app.UseCors("AllowLocalFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
