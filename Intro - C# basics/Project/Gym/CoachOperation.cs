using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

public interface ICoachOperations
{
    public List<Coach> GetAllCoaches();
    public Coach GetCoachById(string id);
    public void AddCoach(Coach coach);
    public void UpdateCoach(Coach coach);
    public void DeleteCoach(string id);
    
    public void PrintAllCoaches();
    public bool GetCoachByEmployeeId(string employeeId);
}

public class CoachOperations : ICoachOperations
{
    private string projectDirectory;

    private string _filePath ;
    private List<Coach> _coaches = new List<Coach>();

    public CoachOperations()
    {
        projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        _filePath = Path.Combine(projectDirectory, "Coach.json");
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            _coaches = JsonConvert.DeserializeObject<List<Coach>>(json) ?? new List<Coach>();
        }
        else
        {
            //create file
            _coaches = new List<Coach>();
            SaveChanges();
        }
    }

    public List<Coach> GetAllCoaches()
    {
        return _coaches;
    }
    public Coach GetCoachById(string id)
    {
        return _coaches.FirstOrDefault(c => c.EmployeeId == id);
    }

    public void AddCoach(Coach coach)
    {
        _coaches.Add(coach);
         SaveChanges();
    }

    public void UpdateCoach(Coach coach)
    {
        var index = _coaches.FindIndex(c => c.EmployeeId == coach.EmployeeId);
        _coaches[index] = coach;
         SaveChanges();
    }

    public void DeleteCoach(string id)
    {
        _coaches.RemoveAll(c => c.EmployeeId == id);
         SaveChanges();
    }

    private void SaveChanges()
    {
        string json = JsonConvert.SerializeObject(_coaches, Formatting.Indented);
         File.WriteAllTextAsync(_filePath, json);
    }
    public void PrintAllCoaches()
    {
        //for each coaches print First Last Name - TaxId
        if (_coaches == null)
        {
            System.Console.WriteLine("No coaches found");
            return;
        }
        foreach (var coach in _coaches)
        {
            System.Console.WriteLine($"{coach.firstname} {coach.lastname} - {coach.taxId}");
        }

    }
    public bool GetCoachByEmployeeId(string employeeId)
    {
        //find coach by card token and chefck wheter it exists
        if(_coaches.FirstOrDefault(c => c.EmployeeId == employeeId) == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}