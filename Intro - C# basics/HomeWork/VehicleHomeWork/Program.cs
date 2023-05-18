//class Program + Main()
/*
Ask the user about the details of each vehicle when taking into consideration the type of vehicle the user wants to add.
After all the information about your cars is entered, Print the details of every car.
Do not forget to use ToString() method.
*/
class Program
{
    static void Main(string[] args)
    {
        string make = "", model = "", year = "", nextServiceDate = "", colorOrName = "", manufacturingYear = "";

        //create Vehicles array
        Vehicle[] vehicles = new Vehicle[3];
        //ask the user about vehicle details ask if it is a car or a boat
        for(int i = 0; i < vehicles.Length; i++)
        {
            Console.WriteLine("Enter the type of vehicle you want to add");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Boat");

            int vehicleType = Convert.ToInt32(Console.ReadLine());

            //Ask for vehicle info
            Console.WriteLine("Enter the details of your vehicle");
            Console.WriteLine("Enter the make of your vehicle");
            make = Console.ReadLine();
            Console.WriteLine("Enter the model of your vehicle");
            model = Console.ReadLine();
            Console.WriteLine("Enter the year of your vehicle");
            year = Console.ReadLine();
            Console.WriteLine("Enter the next service date of your vehicle");
            nextServiceDate = Console.ReadLine();
            Console.WriteLine("Enter the manufacturing Year of your vehicle");
            manufacturingYear = Console.ReadLine();
            Console.WriteLine("Enter the "+ ((vehicleType == 1) ? "Color" : "BoatName"));
             colorOrName = Console.ReadLine();
            vehicles[i] = (vehicleType == 1) ? new Car( make,  model,  manufacturingYear,  nextServiceDate,  colorOrName) : new Boat( make,  model,  manufacturingYear,  nextServiceDate,  colorOrName);
        }
        //Print the details of each vehicle
        for(int i = 0; i < vehicles.Length; i++)
        {
            Console.WriteLine(vehicles[i].ToString());
        }
        
    }
}