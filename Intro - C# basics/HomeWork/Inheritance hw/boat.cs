//3) Create another subclass named Boat
//This class will have an additional member: BoatName.

class Boat : Vehicle
{
    public string boat_name;

    //Constructor function
    public Boat(string make, string model, string manufacuring_year, string next_service_date, string boat_name) : base(make, model, manufacuring_year, next_service_date)
    {
        //initialize all variables with parameter
        this.make = make;
        this.model = model;
        this.manufacuring_year = manufacuring_year;
        this.next_service_date = next_service_date;
        this.boat_name = boat_name;
    }
    //constructor without parameter
    public Boat()
    {
        //initialize all variable with nothing
        this.make = "";
        this.model = "";
        this.manufacuring_year = "";
        this.boat_name = "";
        this.next_service_date = "";
    }

    //override ToString()
    public override string ToString()
    {
        return $"{make}  -{model} - {manufacuring_year} - {next_service_date} - {boat_name}";
    }
}
