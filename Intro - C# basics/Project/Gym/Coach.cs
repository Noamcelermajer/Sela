public class Coach : Person
{
    public string EmployeeId { get; set; }
    public string BankDetails { get; set; }
    public string Grade { get; set; }

    public Coach(string taxId, string firstName, string lastName, string gender, DateTime birthDate,
        string phone, string email, string profession, string status, string employeeId, string bankDetails, string grade)
        : base(taxId, firstName, lastName, gender, birthDate, phone, email, profession, status)
    {
        EmployeeId = employeeId;
        BankDetails = bankDetails;
        Grade = grade;
    }

    // Other methods and properties
}