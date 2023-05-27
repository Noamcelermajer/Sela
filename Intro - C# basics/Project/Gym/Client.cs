using System.Text.RegularExpressions;
public class Client : Person
{
    public string cardToken = "";
    public string medicalLimits = "";


    public double height { get; set; }
    public double weight { get; set; }
    public double fatPercent { get; set; }

    public Client(string taxId, string firstName, string lastName, string gender, DateTime birthDate,
        string phone, string email, string profession, string status, string cardToken, string medicalLimits,
        double height, double weight, double fatPercent)
        : base(taxId, firstName, lastName, gender, birthDate, phone, email, profession, status)
    {
        this.cardToken = cardToken;
        this.medicalLimits = medicalLimits;
        this.height = height;
        this.weight = weight;
        this.fatPercent = fatPercent;
    }
}