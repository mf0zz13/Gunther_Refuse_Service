namespace GuntherRefuse.Model
{
    public class Employee : ObservableObject
    {
        // Propertites that are stored in the database 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public int NumberOfIncidents { get; set; }

        // Properties that are minipulated in for user display 
        public string StartDateFormatted { get; set; }
        public string NameFormatted { get; set; }
    }
}
