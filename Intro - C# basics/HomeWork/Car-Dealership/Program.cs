using OpenAI_API;
class Program
{
    static async Task Main(string[] args)
    {
        string user_question = "";
        OpenAIAPI api = new OpenAIAPI("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");
        string answer = "";

        var chat = api.Chat.CreateConversation();
        CarDealership dealership = new CarDealership();

        //add cars
        int choice = 0;
        chat.AppendSystemMessage("Your a car dealership your job is to get user car model which he is interested and explain why it is a good car");
        dealership.addCsv("C:/Text File/car.csv");
        while (true)
        {
            //print dealership catalog
            dealership.print_dealership_catalog();
            //get user input for car model
            Console.WriteLine("Choose a model");
            Console.WriteLine("enter -1 to Exit !");


            //print car in index[choice]
            choice = int.Parse(Console.ReadLine());
            if(choice == -1 )
            {
                break;
            }
            if (choice >= dealership.count)
            {
                Console.WriteLine("Invalid choice");
                continue;
            }
                Console.WriteLine(dealership);
                chat.AppendUserInput("The Car im interested in is "+ dealership.get_cars()[choice].ToString() + " why is it a good car ");
                // and get the response
                Console.WriteLine("Please await for human corespondent to connect...");
                string response = await chat.GetResponseFromChatbot();
                Console.WriteLine(response);
                //ask user if he wish to buy 
                while(Console.KeyAvailable) 
                    Console.ReadKey(false); // skips previous input chars
                while(answer != "n"){
                    Console.WriteLine("Do you have anymore question about the car ? (y/n)");
                    answer = Console.ReadLine();
                    if(answer == "y")
                    {
                        Console.WriteLine("Please Enter your question about the car :");
                        user_question = Console.ReadLine();
                        chat.AppendUserInput(user_question);
                        response = await chat.GetResponseFromChatbot();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(response);
                        //ask user if he wish to buy 
                        while(Console.KeyAvailable) 
                            Console.ReadKey(false); // skips previous input chars
                    }
                Console.WriteLine("Do you wish to buy this car? (y/n)");
                answer = Console.ReadLine();

                if (answer == "y")
                {
                    //remove car from dealership array
                    dealership.remove_car(choice);
                    Console.WriteLine("Thank you for your purchase we wish the best!");
                    break;
                }
            }
        }
    }
}

