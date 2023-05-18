//this file contain car class declaration + function if needed

class Car
{
    public string model;
    public string color;
    public int year;
    public string maker;
    public int price;
    public int km;

    //constructor
    public Car(string model, string color, int year, string maker, int price, int km)
    {
        this.model = model;
        this.color = color;
        this.year = year;
        this.maker = maker;
        this.price = price;
        this.km = km;
    }
    //overloaded
    //tostring
    public override string ToString()
    {
        return $"{model} - {color} - {year} - {maker} - ${price} - {km} km";
    }
}
