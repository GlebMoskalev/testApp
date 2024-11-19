public class WeatherForecast
{
    public int Id { get; set; } // Primary Key
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
    public string Location { get; set; } // Местоположение
    public int Humidity { get; set; } // Влажность
    public int WindSpeed { get; set; } // Скорость ветра
}