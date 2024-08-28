namespace GuntherRefuse.Models
{
    public class Truck : ObservableObject
    {
        int _truckNumber;
        string _truckNumberFormatted;
        string _dispatchFormatted;

        // Properties that are stored in database
        public int TruckNumber 
        {
            get => _truckNumber;
            set
            {
                _truckNumberFormatted = $"Truck Number: {value}";
                _dispatchFormatted = $"Dispatch Truck {value}";
                _truckNumber = value;
            }
        }
        public int Available { get; set; }

        // Properties that are minipulated in for user display
        public string TruckNumberFormatted { get => _truckNumberFormatted; }
        public string DispatchFormatted { get => _dispatchFormatted; }
    }
}
    
