using System.Runtime.Versioning;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    public List<Features> features {get; set; }

}

public class EarthquakeProperties
{
    public double mag { get; set; }
    public string place { get; set; }

}
public class Features
{

    public EarthquakeProperties properties {get; set; }
}