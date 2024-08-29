namespace GuntherRefuse.Models
{
    public class Employee
    {
        // Propertites that are stored in the database 

        public int EmployeeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public int HasCDL { get; set; }

        // Properties that are minipulated in for user display 
        public string StartDateFormatted { get; set; }
        public string NameFormatted { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
