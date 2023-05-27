//this file contain class of car dealership which contains an array of car to sale 

class CarDealership
{
    private Car[] cars ;
    public int count;
    public CarDealership()
    {
        cars = new Car[0];
        count = 0;
    }

    public Car[] get_cars()
    {
        return cars;
    }
    public void Add(Car car)
    {
        Car[] tmp = new Car[cars.Length + 1];
        for (int i = 0; i < cars.Length; i++)
        {
            tmp[i] = cars[i];
        }
        tmp[cars.Length] = car;
        cars = tmp;
        count++;
    }
    //print all car with relevant info
    public void Print()
    {
        for (int i = 0; i < count; i++)
            Console.WriteLine(cars[i].ToString());

    }
    //function that get string and return if car model already exist
    public bool Contains(string model)
    {
        for (int i = 0; i < count; i++)
        {
            if (cars[i].model == model)
            {
                return true;
            }
        }
        return false;
    }
    public void print_dealership_catalog()
    {
        Console.WriteLine("Welcome to Noam car Dealership");
        Console.WriteLine("Cars in stock: " + count);
        for(int i =0;i < count;i++)
        {
            Console.WriteLine($"{i}. {cars[i].model} - {cars[i].km} - ${cars[i].price}"); 
        }

    }

    //function that get csv and add car to array
    public void addCsv(string csv_path)
    {
        string[] lines = System.IO.File.ReadAllLines(csv_path);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            //if model dont already exist in array add it
            if (!Contains(parts[0]))
            {
                Add(new Car(parts[0], parts[1], int.Parse(parts[2]), parts[3], int.Parse(parts[4]), int.Parse(parts[5])));
            }
        }

    }

    //function that get index and remove car from dealership array
    public void remove_car(int index)
    {
        Car[] tmp = new Car[cars.Length - 1];
        for (int i = 0; i < cars.Length; i++)
        {
            if (i != index)
            {
                tmp[i] = cars[i];
            }
            

        }
        cars = tmp;
    }
}