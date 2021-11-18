using Task1Library;

namespace Task1
{
    [TrackingEntity]
    public class Task1Testing
    {
        public string cash;

        [TrackingProperty("Mark")]
        public int Mark { get; set; }

        [TrackingProperty("length")]
        public static double Length => 8.0;

        [TrackingProperty("weight")]
        public int Weight = 158;

        [TrackingProperty(null)]
        public string Name = "name";
    }
}