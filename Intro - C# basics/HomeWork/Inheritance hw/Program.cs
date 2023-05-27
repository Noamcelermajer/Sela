class Program
{
   //In the Main function, create an array of vehicles size 3,4 elements.
    static void Main(string[] args)
    {
        //create array of vehicle
        Vehicle[] vehicles = new Vehicle[3];
        //ask user for vehicle details and add vehicle to array of vehicle into consideration the type of vehicle the user wants to add.
        for (int i = 0; i < vehicles.Length; i++)
        {
            Console.WriteLine("Please enter vehicle info is it a boat/car please respond with (b/c)");
            string vehicle_type = Console.ReadLine();
            
            Console.WriteLine("Enter vehicle details");
            Console.WriteLine("Enter make");
            string make = Console.ReadLine();
            Console.WriteLine("Enter model");
            string model = Console.ReadLine();
            Console.WriteLine("Enter manufacuring year");
            string manufacuring_year = Console.ReadLine();
            Console.WriteLine("Enter next service date");
            string next_service_date = Console.ReadLine();
            Console.WriteLine(vehicle_type == "b" ? "Enter boat name" : "Enter car color");
            string temp = Console.ReadLine();
            //create vehicle object
            if (vehicle_type == "b")
            {
                vehicles[i] = new Boat(make, model, manufacuring_year, next_service_date, temp);
            }
            else
            {
                vehicles[i] = new Cars(make, model, manufacuring_year, next_service_date, temp);
            }
        }
        //print vehicle details
        for (int i = 0; i < vehicles.Length; i++)
        {
            Console.WriteLine(vehicles[i].ToString());
        }

    }
}