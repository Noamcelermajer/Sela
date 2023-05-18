/* 
Vehicle class Declaration :
    Create a class Vehicle with the members:
    Make, Model, Manufacturing year, next service date (as string only).
*/

public class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string ManufacturingYear { get; set; }
    public string NextServiceDate { get; set; }
    //Constructor 


}

/*
Car : Vehicle class Declaration :
    Create a subclass (inherited class) to Vehicle class named Cars.
    This class will have an additional member: Color.
*/

class Car : Vehicle
{
    public string Color { get; set; }
     
    //Constructor
    public Car(string make, string model, string manufacturingYear, string nextServiceDate, string color)
    {
        Make = make;
        Model = model;
        ManufacturingYear = manufacturingYear;
        NextServiceDate = nextServiceDate;
        Color = color;
    }
    //ToString 
    public override string ToString()
    {
        //Make nice output
        return Make + " - " + Model + " - " + ManufacturingYear + " - " + NextServiceDate + " - " + Color;
        
    }
}

/*
Boat : Vehicle class Declaration :
    Create another subclass named Boat
    This class will have an additional member: BoatName.
*/

class Boat : Vehicle
{
    public string BoatName { get; set; }
    public Boat(string make, string model, string manufacturingYear, string nextServiceDate, string boatName)
    {
        Make = make;
        Model = model;
        ManufacturingYear = manufacturingYear;
        NextServiceDate = nextServiceDate;
        BoatName = boatName;
    }
        public override string ToString()
    {
        //Make nice output
        return Make + " - " + Model + " - " + ManufacturingYear + " - " + NextServiceDate + " - " + BoatName;
        
    }
}