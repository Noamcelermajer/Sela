using System;
public class EntityMenu
{
    private readonly List<string> _options;
    private int _selectedOptionIndex = 0;

    public EntityMenu()
    {
        _options = new List<string>
        {
            "Manage Clients",
            "Manage Coaches",
            "Exit"
        };
    }


    public void MenuLogic()
    {
        var clientOperations = new ClientOperations();
        var coachOperations = new CoachOperations();
        var gmsHandler = new GMSHandler(clientOperations, coachOperations);

        var entityMenu = new EntityMenu();
        int selectedEntityIndex;
            
        do
        {
            selectedEntityIndex = entityMenu.ShowMenu();

            switch (selectedEntityIndex)
            {
                    case 0:
                         ManageClients(clientOperations, gmsHandler);
                        break;
                    case 1:
                         ManageCoaches(coachOperations, gmsHandler);
                        break;
                }

            } while (selectedEntityIndex != 2);

            Console.WriteLine("Exiting program...");
    }
    public EntityMenu(List<string> options)
    {
        _options = options;
    }

    public int ShowMenu()
    {
        ConsoleKeyInfo keyInfo;

        do
        {
            Console.Clear();

            for (int i = 0; i < _options.Count; i++)
            {
                if (i == _selectedOptionIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }

                Console.WriteLine(_options[i]);

                Console.ResetColor();
            }

            keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    _selectedOptionIndex = Math.Max(0, _selectedOptionIndex - 1);
                    break;
                case ConsoleKey.DownArrow:
                    _selectedOptionIndex = Math.Min(_options.Count - 1, _selectedOptionIndex + 1);
                    break;
                case ConsoleKey.Enter:
                    return _selectedOptionIndex;
            }
        } while (keyInfo.Key != ConsoleKey.Escape);

        return -1;
    }

    public int ShowClientOptions()
    {
        _options.Clear();
        _options.Add("Add a Client");
        _options.Add("Update a Client");
        _options.Add("Delete a Client");
        _options.Add("List all Clients");
        _options.Add("Back");

        ConsoleKeyInfo keyInfo;

        do
        {
            Console.Clear();

            for (int i = 0; i < _options.Count; i++)
            {
                if (i == _selectedOptionIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }

                Console.WriteLine(_options[i]);

                Console.ResetColor();
            }

            keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    _selectedOptionIndex = Math.Max(0, _selectedOptionIndex - 1);
                    break;
                case ConsoleKey.DownArrow:
                    _selectedOptionIndex = Math.Min(_options.Count - 1, _selectedOptionIndex + 1);
                    break;
                case ConsoleKey.Enter:
                    return _selectedOptionIndex;
            }
        } while (keyInfo.Key != ConsoleKey.Escape);

        return -1;
    }

    public int ShowCoachOptions()
    {
        _options.Clear();
        _options.Add("Add a Coach");
        _options.Add("Update a Coach");
        _options.Add("Delete a Coach");
        _options.Add("List all Coaches");
        _options.Add("Back");

        ConsoleKeyInfo keyInfo;

        do
        {
            Console.Clear();
            
            for (int i = 0; i < _options.Count; i++)
            {
                if (i == _selectedOptionIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }

                Console.WriteLine(_options[i]);

                Console.ResetColor();
            }

            keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    _selectedOptionIndex = Math.Max(0, _selectedOptionIndex - 1);
                    break;
                case ConsoleKey.DownArrow:
                    _selectedOptionIndex = Math.Min(_options.Count - 1, _selectedOptionIndex + 1);
                    break;
                case ConsoleKey.Enter:
                    return _selectedOptionIndex;
            }
        } while (keyInfo.Key != ConsoleKey.Escape);

        // Return -1 if the loop exits with the escape key
        return -1;
    }
    public void ManageClients(ClientOperations clientOperations, GMSHandler gmsHandler)
    {
        int selectedOptionIndex;
        do
        {
            var clientMenu = new EntityMenu();
            selectedOptionIndex = clientMenu.ShowClientOptions();

            switch (selectedOptionIndex)
            {
                case 0:
                    Console.WriteLine("Adding a new client...");
                    var newClient = gmsHandler.GetClientFromUserInput();
                     gmsHandler.AddClient(newClient);
                    Console.WriteLine("Client added successfully.");
                    Console.ReadLine();
                    break;
                case 1:
                    gmsHandler.UpdateClient();
                    break;
                case 2:
                    Console.WriteLine("Deleting a client...");
                    gmsHandler.DeleteClient();
                    Console.WriteLine("Client deleted successfully.");
                    break;
                case 3:
                    Console.WriteLine("Listing all clients...");
                    gmsHandler.ListAllClients();
                    Console.WriteLine("Enter a Key to exit");
                    Console.ReadLine();

                    break;
                case 4: // Back
                    return;
                default :
                    Console.WriteLine("Invalid option.");
                    break;
            }

        } while (selectedOptionIndex != 4);
    }

    public void ManageCoaches(CoachOperations coachOperations, GMSHandler gmsHandler)
    {
        while (true)
        {
            Console.Clear();
            var menu = new EntityMenu();
            var selectedOption = menu.ShowCoachOptions();

            switch (selectedOption)
            {
                case 0: // Add a Coach
                    Console.WriteLine("Add a Coach");
                    var coachToAdd = gmsHandler.GetCoachFromUserInput();
                    gmsHandler.AddCoach(coachToAdd);
                    Console.WriteLine("Coach added successfully.");
                    break;

                case 1:
                    gmsHandler.UpdateCoach();
                    break;

                case 2: // Delete a Coach
                    Console.WriteLine("Delete a Coach");
                    gmsHandler.DeleteCoach();
                    Console.WriteLine("Coach deleted successfully.");
                    break;
                case 3: // List all Coaches
                    Console.WriteLine("Listing all clients...");
                    gmsHandler.ListAllCoaches();
                    Console.WriteLine("Enter a Key to exit");
                    Console.ReadLine();
                    break;
                case 4: // Back
                    return;
                default :
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }


    
}
