namespace GuntherRefuse.Models
{
    public class Dispatch
    {
        private string _formattedTruckName;
        private string _formattedRoute;
        private string _formattedCollectionType;
        private int _truckNumber;
        private int _serviceArea;
        private int _collectionType;

        // Properties for database items
        public int TruckNumber
        {
            get => _truckNumber;
            set
            {
                _truckNumber = value;
                _formattedTruckName = $"Truck: {value}";
            }
        }
        public int ServiceArea
        {
            get => _serviceArea;
            set
            {
                _serviceArea = value;
                _formattedRoute = $"Route: {value}";
            }
        }
        public DateTime Date { get; set; }
        public int Driver { get; set; }
        public int HelperOne { get; set; }
        public int HelperTwo { get; set; }
        public int HelperThree { get; set; }
        public int TrashOrRecyclingOrYard
        {
            get => _collectionType;
            set
            {
                _collectionType = value;

                switch (value)
                {
                    case 1:
                        _formattedCollectionType = "Collection: Trash";
                        break;
                    case 2:
                        _formattedCollectionType = "Collection: Recycling";
                        break;
                    case 3:
                        _formattedCollectionType = "Collection: Yard Waste";
                        break;
                }
            }
        }

        public string FormattedTruckName { get => _formattedTruckName; }
        public string FormattedRoute { get => _formattedRoute; }
        public string FormattedCollectionType { get => _formattedCollectionType; }
    }
}
