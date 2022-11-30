namespace Template;
public abstract class HouseTemplate
{
    // Template method defines the sequence for building a house
    public void BuildHouse()
    {
        BuildFoundation();
        BuildPillars();
        BuildWalls();
        BuildWindows();
        Console.WriteLine("House is built");
    }
    // Methods to be implemented by subclasses
    public abstract void BuildFoundation();
    public abstract void BuildPillars();
    public abstract void BuildWalls();
    public abstract void BuildWindows();
}

public class ConcreteHouse : HouseTemplate
{
    public override void BuildFoundation()
    {
        Console.WriteLine("Building foundation with cement, iron rods and sand");
    }
    public override void BuildPillars()
    {
        Console.WriteLine("Building Concrete Pillars with Cement and Sand");
    }
    public override void BuildWalls()
    {
        Console.WriteLine("Building Concrete Walls");
    }
    public override void BuildWindows()
    {
        Console.WriteLine("Building Concrete Windows");
    }
}

public class WoodenHouse : HouseTemplate
{
    public override void BuildFoundation()
    {
        Console.WriteLine("Building foundation with cement, iron rods, wood and sand");
    }
    public override void BuildPillars()
    {
        Console.WriteLine("Building wood Pillars with wood coating");
    }
    public override void BuildWalls()
    {
        Console.WriteLine("Building Wood Walls");
    }
    public override void BuildWindows()
    {
        Console.WriteLine("Building Wood Windows");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Build a Concrete House\n");
        HouseTemplate houseTemplate = new ConcreteHouse();
        houseTemplate.BuildHouse();// call the template method
        Console.WriteLine("Build a Wooden House\n");
        houseTemplate = new WoodenHouse();
        houseTemplate.BuildHouse();// call the template method
    }
}