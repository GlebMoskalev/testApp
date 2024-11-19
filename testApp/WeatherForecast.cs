public class WeatherForecast
{
    public int Id { get; set; } // Primary Key
    public DateTime Date { get; set; }
    public decimal TemperatureC { get; set; } // Изменен тип данных на decimal
    public string Summary { get; set; }
    public string Location { get; set; } // Местоположение
    public int Humidity { get; set; } // Влажность
    public int WindSpeed { get; set; } // Скорость ветра
    public int Pressure { get; set; } // Давление
    public int Visibility { get; set; } // Видимость
}