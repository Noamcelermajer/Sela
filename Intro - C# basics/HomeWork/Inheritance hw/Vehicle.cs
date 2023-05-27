/*
Cars assignment:
1) Create a class Vehicle with the members:
Make, Model, Manufacturing year, next service date (as string only).

*/
//Create a class Vehicle with the members:
//Make, Model, Manufacturing year, next service date (as string only).
class Vehicle
{
    public string make;
    public string model;
    public string manufacuring_year;
    public string next_service_date;

    //Constructor with parameter
    public Vehicle(string make, string model, string manufacuring_year, string next_service_date)
    {
        this.make = make;
        this.model = model;
        this.manufacuring_year = manufacuring_year;
        this.next_service_date = next_service_date;
    }
    //constructor without parameter
    public Vehicle()
    {
        //initialize all variable with nothing
        this.make = "";
        this.model = "";
        this.manufacuring_year = "";
        this.next_service_date = "";
    }
    //override
    //tostring
    public override string ToString()
    {
        return $"{make} {model} {manufacuring_year} {next_service_date}";

    }

}