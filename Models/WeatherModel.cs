

public class WeatherModel
{
    // Location
    // Current
    public Location ?location {get; set;}
    
    public Current ?Current { get; set;}

    public decimal wind_mph { get; set;}

    //public decimal ?WindKph { get; set;}

    //public decimal ?Humidity { get; set;}






}

public class Location {

    public string name { get; set; }

    public string region { get; set; }

    public string country { get; set; }

    public decimal lat { get; set; }

    public decimal lon { get; set; }

    public string tz_id { get; set; }
}

public class Current
{

 
    public decimal temp_c { get; set; }


        

}