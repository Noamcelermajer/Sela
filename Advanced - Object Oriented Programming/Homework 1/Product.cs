using System;
public class Product
{
    private string _productName;
    private double _productPrice;
    private DateTime _warrantyExpiry;

    public Product(string name, double price, int numOfDays)
    {
        _productName = name;
        _productPrice = price > 0 ? price : 100;
        _warrantyExpiry = DateTime.Now.AddDays(numOfDays);
    }

    public string GetName() => _productName;
    public double GetPrice() => _productPrice;
    public DateTime GetWarrantyExpiry() => _warrantyExpiry;

    public override string ToString()
    {
        return $"Name: {_productName}, Price: {_productPrice}, Warranty Expiry: {_warrantyExpiry.ToShortDateString()}";
    }
}