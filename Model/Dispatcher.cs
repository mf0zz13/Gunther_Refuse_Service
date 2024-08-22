namespace GuntherRefuse.Model
{
    public class Dispatcher : ObservableObject
    {
        // Properties that are stored in database
        public int TruckNumber { get; set; }
        public int Available { get; set; }

        // Properties that are minipulated in for user display
        public string TruckNumberFormatted { get; set; }
    }
}
    
