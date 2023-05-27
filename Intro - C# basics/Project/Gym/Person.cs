public class Person
{
    public string taxId { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string gender { get; set; }
    public DateTime birthDate { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public string profession { get; set; }
    public string status { get; set; }

    public Person(string taxId, string firstName, string lastName, string gender, DateTime birthDate,
        string phone, string email, string profession, string status)
    {
        this.taxId = taxId;
        this.firstname = firstName;
        this.lastname = lastName;
        this.gender = gender;
        this.birthDate = birthDate;
        this.phone = phone;
        this.email = email;
        this.profession = profession;
        this.status = status;
    }
}
