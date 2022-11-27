namespace Flyweight;

public interface Flyweight
{
    void Operation(string Ammotype);
}

public class ConcreteFlyweight : Flyweight
{
    public void Operation(string ammo)
    {
        Console.WriteLine(" Ammo type: " + ammo);
    }
}

public class FlyweightFactory
{
    private static Dictionary<string, Flyweight> _flyweights = new();

    public FlyweightFactory()
    {
        _flyweights.Add("Shotgun", new ConcreteFlyweight());
        _flyweights.Add("Pistol", new ConcreteFlyweight());
        _flyweights.Add("Rifle", new ConcreteFlyweight());
    }

    public Flyweight GetFlyweight(string key) => _flyweights[key];     //return ammo type

}
class Program
{

    static void Main()
    {
        FlyweightFactory factory = new FlyweightFactory();
        // Work with different flyweight instances
        Flyweight remington = factory.GetFlyweight("Shotgun");
        remington.Operation("Shotguns");

        Flyweight glock = factory.GetFlyweight("Pistol");
        glock.Operation("Pistols");

        Flyweight Ak47 = factory.GetFlyweight("Rifle");
        Ak47.Operation("Rifles");

        Flyweight M16 = factory.GetFlyweight("Rifle");
        M16.Operation("Rifles (new)");
    }
}