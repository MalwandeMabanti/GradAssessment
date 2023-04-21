
public class WeatherModel
{
    public Location location { get; set; }
    public Current current { get; set; }
}

public class Location
{
    public string name { get; set; }

    public string localtime { get; set; }
}

public class Current
{
    public string last_updated { get; set; }
    public float temp_c { get; set; }
    public int is_day { get; set; }
    public float wind_kph { get; set; }
    public int wind_degree { get; set; }
    public string wind_dir { get; set; }
    public int humidity { get; set; }
    public int cloud { get; set; }
}