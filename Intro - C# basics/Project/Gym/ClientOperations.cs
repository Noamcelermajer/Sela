using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

public interface IClientOperations
{
    public List<Client> GetAllClients();
    public Client GetClientById(string id);
    public void  UpdateClient( Client client);
    public void  DeleteClient(string id);
    public void  AddClient(Client client);
    public void PrintAllClients();
    public bool GetClientByCardToken(string cardToken);
}

public class ClientOperations : IClientOperations
{
    private readonly string _filePath;
    private List<Client> _clients = new List<Client>();
    private string projectDirectory;

    public ClientOperations()
    {

        projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        _filePath = Path.Combine(projectDirectory, "Client.json");
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            _clients = JsonConvert.DeserializeObject<List<Client>>(json) ?? new List<Client>();
        }
        else
        { 
            //create file
            _clients = new List<Client>();
            SaveChanges();

        }
    }

    public List<Client> GetAllClients()
    {
        return _clients;
    }

    public Client GetClientById(string id)
    {
        return _clients.FirstOrDefault(c => c.taxId == id);
    }

    public void AddClient(Client client)
    {
        _clients.Add(client);
        SaveChanges();
    }

    public void UpdateClient(Client client)
    {
        var index = _clients.FindIndex(c => c.taxId == client.taxId);
        _clients[index] = client;
        SaveChanges();
    }

    public void  DeleteClient(string id)
    {
        _clients.RemoveAll(c => c.taxId == id);
         SaveChanges();
    }

    private void  SaveChanges()
    {
        string json = JsonConvert.SerializeObject(_clients, Formatting.Indented);
        File.WriteAllTextAsync(_filePath, json);
    }
    public void  PrintAllClients()
    {   
        //print for each client first and last name + TaxId
        if (_clients == null)
        {
            System.Console.WriteLine("No coaches found");
            return;
        }
        foreach (Client client in _clients)
        {
            Console.WriteLine($"Client: {client.firstname} {client.lastname} - {client.taxId}");
        }
    }
    public bool GetClientByCardToken(string cardToken)
    {
        //find coach by card token and chefck wheter it exists
        if(_clients.FirstOrDefault(c => c.cardToken == cardToken) == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
