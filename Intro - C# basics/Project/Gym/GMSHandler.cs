using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class GMSHandler
{
    private readonly IClientOperations _clientOperations;
    private readonly ICoachOperations _coachOperations;
    private static Random random = new Random();


    private RegexHelper reg ;
    public GMSHandler(IClientOperations clientOperations, ICoachOperations coachOperations)
    {
        _clientOperations = clientOperations;
        _coachOperations = coachOperations;
        reg = new RegexHelper();
    }

    public void ListAllClients()
    {
        _clientOperations.PrintAllClients();
    }

    public void AddClient(Client client)
    {
        if (client == null)
        {
            System.Console.WriteLine("Couldnt Add()");
        }

        _clientOperations.AddClient(client);
    }

    public void DeleteClient()
    {
        var clients =  _clientOperations.GetAllClients();

        if (clients.Count == 0)
        {
            Console.WriteLine("No clients found.");
            return;
        }

        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();

            for (int i = 0; i < clients.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }

                Console.WriteLine($"{clients[i].firstname} {clients[i].lastname}");
            }

            var keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = Math.Max(0, selectedIndex - 1);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = Math.Min(clients.Count - 1, selectedIndex + 1);
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                var clientToDelete = clients[selectedIndex];
                 _clientOperations.DeleteClient(clientToDelete.taxId);
                Console.WriteLine("Client deleted successfully.");
                Console.ReadLine();
                return;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                return;
            }
        }
    }

    

    public void ListAllCoaches()
    {
        _coachOperations.PrintAllCoaches();
    }

    public void AddCoach(Coach coach)
    {
         _coachOperations.AddCoach(coach);
    }
    public string createReg(string prompt , string Regex, string errorMessage)
    {
        //update reg variable field 
        reg.prompt = prompt;
        reg.pattern = Regex;
        reg.errorMessage = errorMessage;
        //call readinput 
        return reg.ReadInput(reg.prompt, reg.pattern, reg.errorMessage);
        

    }
    public void  UpdateClient()
    {
        Console.WriteLine("Updating a Client...");
        List<Client> allClient =  _clientOperations.GetAllClients();
        var selectedIndex = 0;
        //check if there are any clients
        if (allClient.Count == 0)
        {
            return;
        }


        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select a client to update:");

            for (int i = 0; i < allClient.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine($"{allClient[i].taxId}: {allClient[i].firstname} {allClient[i].lastname}");
            }

            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = Math.Max(0, selectedIndex - 1);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = Math.Min(allClient.Count - 1, selectedIndex + 1);
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                return;
            }
        }


        var existingClient = allClient[selectedIndex];

        if (existingClient == null)
        {
            throw new InvalidOperationException("Client does not exist.");
        }
        var options = new List<string> { "TaxId", "FirstName", "LastName", "Gender", "BirthDate", "Phones", "Email", "Profession", "Status", "CardToken", "MedicalLimits", "Height", "Weight", "FatPercent" };

        while (true)
        {
            Console.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
            }

            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = Math.Max(0, selectedIndex - 1);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = Math.Min(options.Count - 1, selectedIndex + 1);
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                return;
            }
        }

        var fieldToUpdate = options[selectedIndex];
        Console.WriteLine($"Updating {fieldToUpdate}");

        switch (fieldToUpdate)
        {
            case "TaxId":
                //Print old Value
                Console.WriteLine($"Old Tax ID: {existingClient.taxId}");
                existingClient.taxId = createReg("Enter the new Tax ID: ", "^[0-9]{9}$", "Invalid Tax ID. Please enter a 9-digit number.");
                break;
            case "FirstName":
                //Print old Value
                Console.WriteLine($"Old First Name: {existingClient.firstname}");
                existingClient.firstname = createReg("Enter the new First Name: ", "^[A-Za-z]{1,50}$", "Invalid First Name. Please enter a name containing only letters and a maximum of 50 characters.");
                break;
            case "LastName":
                //Print old Value
                Console.WriteLine($"Old Last Name: {existingClient.lastname}");
                existingClient.lastname = createReg("Enter the new Last Name: ", "^[A-Za-z]{1,50}$", "Invalid Last Name. Please enter a name containing only letters and a maximum of 50 characters.");
                break;
            case "Gender":
                //Print old Value
                Console.WriteLine($"Old Gender: {existingClient.gender}");
                existingClient.gender = createReg("Enter the new Gender: ", "^(Male|Female|Other)$", "Invalid Gender. Please enter 'Male', 'Female', or 'Other'.");
                break;
            case "BirthDate":
                //Print old Value
                Console.WriteLine($"Old Birth Date: {existingClient.birthDate}");
                existingClient.birthDate = DateTime.Parse(createReg("Enter the new Birth Date (YYYY-MM-DD): ", @"^\d{4}-\d{2}-\d{2}$", "Invalid Birth Date. Please enter in format YYYY-MM-DD."));
                break;
            case "Phones":
                //Print old Value
                Console.WriteLine($"Old Phone Number: {existingClient.phone}");
                existingClient.phone = createReg("Enter the new Phone Number: ", @"^\+?\d{1,4}[-\s]?\(?\d{1,3}?\)?[-\s]?\d{1,4}[-\s]?\d{1,4}[-\s]?\d{1,9}$", "Invalid Phone Number. Please enter a valid phone number.");
                break;
            case "Email":
                //Print old Value
                Console.WriteLine($"Old Email: {existingClient.email}");
                existingClient.email = createReg("Enter the new Email: ", @"^[^@\s]+@[^@\s]+\.[^@\s]+$", "Invalid Email. Please enter a valid email address.");
                break;
            case "Profession":
                //Print old Value
                Console.WriteLine($"Old Profession: {existingClient.profession}");
                existingClient.profession = createReg("Enter the new Profession: ", "^[A-Za-z\\s]{1,100}$", "Invalid Profession. Please enter a profession containing only letters and spaces with a maximum of 100 characters.");
                break;
            case "Status":
                //Print old Value
                Console.WriteLine($"Old Status: {existingClient.status}");
                existingClient.status = createReg("Enter the new Status: ", "^[A-Za-z\\s]{1,100}$", "Invalid Status. Please enter a status containing only letters and spaces with a maximum of 100 characters.");
                break;
            case "CardToken":
                //Print old Value
                Console.WriteLine($"Old Card Token: {existingClient.cardToken}");
                existingClient.cardToken = createReg("Enter the new Card Token: ", "^[A-Za-z0-9]{1,50}$", "Invalid Card Token. Please enter a token containing only letters and numbers with a maximum of 50 characters.");
                break;
            case "MedicalLimits":
                //Print old Value
                Console.WriteLine($"Old Medical Limits: {existingClient.medicalLimits}");
                existingClient.medicalLimits = createReg("Enter the new Medical Limits: ", "^[A-Za-z0-9\\s]{1,100}$", "Invalid Medical Limits. Please enter a valid input containing only letters, numbers, and spaces with a maximum of 100 characters.");
                break;
            case "Height":
                //Print old Value
                Console.WriteLine($"Old Height : {existingClient.height}");
                existingClient.height = double.Parse(createReg("Enter the new Height: ", "^([0-9]*[.])?[0-9]+$", "Invalid Height. Please enter a valid number."));
                break;
            case "Weight":
                Console.WriteLine($"Old Weight : {existingClient.weight}");
                existingClient.weight = double.Parse(createReg("Enter the new Weight: ", "^([0-9]*[.])?[0-9]+$", "Invalid Weight. Please enter a valid number."));
                break;
            case "FatPercent":                
                Console.WriteLine($"Old Fat Percent : {existingClient.fatPercent}");
                existingClient.fatPercent = double.Parse(createReg("Enter the new Fat Percentage: ", "^([0-9]*[.])?[0-9]+$", "Invalid Fat Percentage. Please enter a valid number."));
                break;
            default:
                throw new InvalidOperationException($"Invalid field: {fieldToUpdate}");

        }

         _clientOperations.UpdateClient(existingClient);
    }
    public void UpdateCoach()
    {
        Console.WriteLine("Updating a Coach...");
        var allCoaches =  _coachOperations.GetAllCoaches();
        var selectedIndex = 0;
        //check if there are any clients
        if (allCoaches.Count == 0)
        {
            return;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select a coach to update:");

            for (int i = 0; i < allCoaches.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine($"{allCoaches[i].taxId}: {allCoaches[i].firstname} {allCoaches[i].lastname}");
            }

            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = Math.Max(0, selectedIndex - 1);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = Math.Min(allCoaches.Count - 1, selectedIndex + 1);
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                return;
            }
        }
        var existingCoach = allCoaches[selectedIndex];

        if (existingCoach == null)
        {
            throw new InvalidOperationException("Coach does not exist.");
        }

        Console.WriteLine("Enter the field you want to update:");
        var options = new List<string> { "TaxId", "FirstName", "LastName", "Gender", "BirthDate", "Phones", "Email", "Profession", "Status", "EmployeeId", "BankDetails", "Grade" };

        selectedIndex  = 0;
        while (true)
        {
            Console.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
            }

            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = Math.Max(0, selectedIndex - 1);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = Math.Min(options.Count - 1, selectedIndex + 1);
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                return;
            }
        }

        var fieldToUpdate = options[selectedIndex];
        Console.WriteLine($"Updating {fieldToUpdate}");

        switch (fieldToUpdate)
        {
            case "TaxId":
                //Print old Value
                Console.WriteLine($"Old Tax ID: {existingCoach.taxId}");
                existingCoach.taxId = createReg("Enter the new Tax ID: ", "^[0-9]{9}$", "Invalid Tax ID. Please enter a 9-digit number.");
                break;
            case "FirstName":
                //Print old Value
                Console.WriteLine($"Old First Name: {existingCoach.firstname}");
                existingCoach.firstname = createReg("Enter the new First Name: ", "^[A-Za-z]{1,50}$", "Invalid First Name. Please enter a name containing only letters and a maximum of 50 characters.");
                break;
            case "LastName":
                //Print old Value
                Console.WriteLine($"Old Last Name: {existingCoach.lastname}");
                existingCoach.lastname = createReg("Enter the new Last Name: ", "^[A-Za-z]{1,50}$", "Invalid Last Name. Please enter a name containing only letters and a maximum of 50 characters.");
                break;
            case "Gender":
                //Print old Value
                Console.WriteLine($"Old Gender: {existingCoach.gender}");
                existingCoach.gender = createReg("Enter the new Gender: ", "^(Male|Female|Other)$", "Invalid Gender. Please enter 'Male', 'Female', or 'Other'.");
                break;
            case "BirthDate":
                //Print old Value
                Console.WriteLine($"Old Birth Date: {existingCoach.birthDate}");
                existingCoach.birthDate = DateTime.Parse(createReg("Enter the new Birth Date (YYYY-MM-DD): ", @"^\d{4}-\d{2}-\d{2}$", "Invalid Birth Date. Please enter in format YYYY-MM-DD."));
                break;
            case "Phones":
                //Print old Value
                Console.WriteLine($"Old Phone Number: {existingCoach.phone}");
                existingCoach.phone = createReg("Enter the new Phone Number: ", @"^\+?\d{1,4}[-\s]?\(?\d{1,3}?\)?[-\s]?\d{1,4}[-\s]?\d{1,4}[-\s]?\d{1,9}$", "Invalid Phone Number. Please enter a valid phone number.");
                break;
            case "Email":
                //Print old Value
                Console.WriteLine($"Old Email: {existingCoach.email}");
                existingCoach.email = createReg("Enter the new Email: ", @"^[^@\s]+@[^@\s]+\.[^@\s]+$", "Invalid Email. Please enter a valid email address.");
                break;
            case "Profession":
                //Print old Value
                Console.WriteLine($"Old Profession: {existingCoach.profession}");
                existingCoach.profession = createReg("Enter the new Profession: ", "^[A-Za-z\\s]{1,100}$", "Invalid Profession. Please enter a profession containing only letters and spaces with a maximum of 100 characters.");
                break;
            case "Status":
                //Print old Value
                Console.WriteLine($"Old Status: {existingCoach.status}");
                existingCoach.status = createReg("Enter the new Status: ", "^[A-Za-z\\s]{1,100}$", "Invalid Status. Please enter a status containing only letters and spaces with a maximum of 100 characters.");
                break;
            case "EmployeeId":
                //Print old Value
                Console.WriteLine($"Old Employee ID: {existingCoach.EmployeeId}");
                existingCoach.EmployeeId = createReg("Enter the new Employee ID: ", "^[0-9]{1,10}$", "Invalid Employee ID. Please enter a number with a maximum of 10 digits.");
                break;
            case "BankDetails":
                //Print old Value
                Console.WriteLine($"Old Bank Details: {existingCoach.BankDetails}");
                existingCoach.BankDetails = createReg("Enter the new Bank Details: ", "^[A-Za-z0-9\\s]{1,100}$", "Invalid Bank Details. Please enter a string containing only letters, numbers, and spaces with a maximum of 100 characters.");
                break;
            case "Grade":
                //Print old Value
                Console.WriteLine($"Old Grade: {existingCoach.Grade}");
                existingCoach.Grade = createReg("Enter the new Grade: ", "^[A-Za-z0-9\\s]{1,50}$", "Invalid Grade. Please enter a string containing only letters, numbers, and spaces with a maximum of 50 characters.");
                break;
            default:
                throw new InvalidOperationException($"Invalid field: {fieldToUpdate}");
        }

         _coachOperations.UpdateCoach(existingCoach);
        return;
    }
    public void DeleteCoach()
    {
        var coaches =  _coachOperations.GetAllCoaches();
        if (coaches.Count == 0)
        {
            Console.WriteLine("No coaches found.");
            return;
        }

        Console.WriteLine("Select a coach to delete:");
        var selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            for (int i = 0; i < coaches.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine($"{coaches[i].firstname} {coaches[i].lastname} ({coaches[i].taxId})");
            }

            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = Math.Max(0, selectedIndex - 1);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = Math.Min(coaches.Count - 1, selectedIndex + 1);
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                return;
            }
        }

        var coachToDelete = coaches[selectedIndex];
         _coachOperations.DeleteCoach(coachToDelete.taxId);
        Console.WriteLine($"Coach {coachToDelete.firstname} {coachToDelete.lastname} ({coachToDelete.taxId}) deleted successfully.");
    }
    public Person GetPersonById(string id)
    {
        var client =  _clientOperations.GetClientById(id);

        if (client != null)
        {
            return client;
        }

        var coach =  _coachOperations.GetCoachById(id);

        if (coach != null)
        {
            return coach;
        }

        return null;
    }
    public Coach GetCoachFromUserInput()
    {
        Console.WriteLine("Enter the following information:");

        string taxId = createReg("Tax ID: ", @"^\d{9}$", "Tax ID must be exactly 9 digits.");
        string firstName = createReg("First Name: ", @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", "Enter a valid first name.");
        string lastName = createReg("Last Name: ", @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", "Enter a valid last name.");
        string gender = createReg("Enter the new Gender: ", "^(Male|Female|Other)$", "Invalid Gender. Please enter 'Male', 'Female', or 'Other'.");
        DateTime birthDate = DateTime.Parse(createReg("Birth Date (YYYY-MM-DD): ", @"^\d{4}-\d{2}-\d{2}$", "Enter a valid date in the format YYYY-MM-DD."));
        string phone = createReg("Phone Number : ", @"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", "Enter a valid phone number.");
        string email = createReg("Email: ", @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*\.[a-zA-Z]{2,7}$", "Enter a valid email address.");
        string profession = createReg("Profession: ", @"^[\w\s]+$", "Enter a valid profession.");
        string status = createReg("Status: ", @"^[\w\s]+$", "Enter a valid status.");
        string employeeId = RandomString(16);
        Console.WriteLine($"Employee ID is generated randomly here is the Employee ID {employeeId}");
        string bankDetails = createReg("Bank Details: ", @"^.+$", "Enter valid bank details.");
        string grade = createReg("Grade: ", @"^[\w\s]+$", "Enter a valid grade.");

        return new Coach(taxId, firstName, lastName, gender, birthDate, phone, email, profession, status, employeeId, bankDetails, grade);
    }
    public Client GetClientFromUserInput()
    {
        Console.WriteLine("Enter the following information:");

        string taxId = createReg("Tax ID: ", @"^\d{9}$", "Tax ID must be exactly 9 digits.");
        string firstName = createReg("First Name: ", @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", "Enter a valid first name.");
        string lastName = createReg("Last Name: ", @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", "Enter a valid last name.");
        string gender = createReg("Gender: ", "^(Male|Female|Other)$", "Invalid Gender. Please enter 'Male', 'Female', or 'Other'.");
        DateTime birthDate = DateTime.Parse(createReg("Birth Date (YYYY-MM-DD): ", @"^\d{4}-\d{2}-\d{2}$", "Enter a valid date in the format YYYY-MM-DD."));
        string phone = createReg("Phone Number : ", @"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", "Enter a valid phone number.");
        string email = createReg("Email: ", @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*\.[a-zA-Z]{2,7}$", "Enter a valid email address.");
        string profession = createReg("Profession: ", @"^[\w\s]+$", "Enter a valid profession.");
        string status = createReg("Status: ", @"^[\w\s]+$", "Enter a valid status.");
        string cardToken = RandomString(16);
        Console.WriteLine($"Card Token is generated randomly here is the cardToken {cardToken}");
        string medicalLimits = createReg("Medical Limits: ", @"^.+$", "Enter valid medical limits.");
        double height = double.Parse(createReg("Height: ", @"^(\d+(\.\d{1,2})?)$", "Enter a valid height with up to 2 decimal places."));
        double weight = double.Parse(createReg("Weight: ", @"^(\d+(\.\d{1,2})?)$", "Enter a valid weight with up to 2 decimal places."));
        double fatPercent = double.Parse(createReg("Fat Percentage: ", @"^(\d+(\.\d{1,2})?)$", "Enter a valid fat percentage with up to 2 decimal places."));

        return new Client(taxId, firstName, lastName, gender, birthDate, phone, email, profession, status, cardToken, medicalLimits, height, weight, fatPercent);
    }
    public string RandomString(int length)
    {

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string ranString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        //check if random string isnt already in use in coaches nor clients
        if (!_coachOperations.GetCoachByEmployeeId(ranString) && !_clientOperations.GetClientByCardToken(ranString))
        {
            return ranString;
        }
        else
        {
            return RandomString(length);
        }

    }

}