public class FeatureCollection
{
    public string Type { get; set; }
    public List<Feature> Features { get; set; }
    public class Feature 
    {
        public string Type { get; set; }
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        public double Mag { get; set; }
        public string Place { get; set; }
        
    }

}