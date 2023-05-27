/* 
2) Create a subclass (inherited class) to Vehicle class named Cars.
This class will have an additional member: Color.
*/

class Cars : Vehicle
{
    public string color;

    //Constructor function
    public Cars(string make, string model, string manufacuring_year, string next_service_date, string color) : base(make, model, manufacuring_year, next_service_date)
    {
        //initialize all variables with parameter
        this.make = make;
        this.model = model;
        this.manufacuring_year = manufacuring_year;
        this.next_service_date = next_service_date;
        this.color = color;
    }
    //constructor without parameter
    public Cars()
    {
        //initialize all variable with nothing
        this.make = "";
        this.model = "";
        this.manufacuring_year = "";
        this.next_service_date = "";
        this.color = "";
    }
    //Tostring function with nice formattign
    public override string ToString()
    {
        return $"{make} - {model} - {manufacuring_year} -  {next_service_date} - {color}";
    }
}