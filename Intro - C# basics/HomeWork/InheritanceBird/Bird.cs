//this class represent all bird it is a template class which each bird will inherit
class Bird
{
    public int weight
    {
        get {return weight; }
        set { weight = value; }
    }
    public int kph
    {
        get { return kph; }
        set { kph = value; }
    }

}
class Duck : Bird
{

}

