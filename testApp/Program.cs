using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext with PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();

    // Добавляем начальные данные
    if (!dbContext.WeatherForecasts.Any())
    {
        dbContext.WeatherForecasts.AddRange(new List<WeatherForecast>
        {
            new WeatherForecast
            {
                Date = DateTime.UtcNow.AddDays(-1),
                TemperatureC = 15,
                Summary = "Cloudy",
                Location = "New York",
                Humidity = 80,
                WindSpeed = 10
            },
            new WeatherForecast
            {
                Date = DateTime.UtcNow,
                TemperatureC = 20,
                Summary = "Sunny",
                Location = "Los Angeles",
                Humidity = 50,
                WindSpeed = 5
            },
            new WeatherForecast
            {
                Date = DateTime.UtcNow.AddDays(1),
                TemperatureC = 10,
                Summary = "Rainy",
                Location = "Seattle",
                Humidity = 90,
                WindSpeed = 15
            }
        });

        dbContext.SaveChanges();
    }
}

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