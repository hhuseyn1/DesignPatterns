namespace FurntFact;

public interface IChair
{
    void HasLegs();
    void SitOn();
}
public interface ISofa
{
    void HasLegs();
    void SitOn();
}
public interface ICoffeeTable
{
    void IsRound();
    void PlaceOn();
}

public abstract class FurnitureFactory
{
    public abstract IChair CreateChair();
    public abstract ISofa CreateSofa();
    public abstract ICoffeeTable CreateCoffeeTable();
}

public class ArtDecoChair : IChair
{
    public void HasLegs() => Console.WriteLine($"{nameof(ArtDecoChair)} has legs");
    public void SitOn() => Console.WriteLine($"Sit on {nameof(ArtDecoChair)}");
}

public class ArtDecoSofa : ISofa
{
    public void HasLegs() => Console.WriteLine($"{nameof(ArtDecoSofa)} has legs");
    public void SitOn() => Console.WriteLine($"Sit on {nameof(ArtDecoSofa)}");

}

public class ArtDecoCoffeeTable : ICoffeeTable
{
    public void IsRound() => Console.WriteLine($"{nameof(ArtDecoCoffeeTable)} isn't round");
    public void PlaceOn() => Console.WriteLine($"You placed {nameof(ArtDecoCoffeeTable)}");
}

public class VictorianChair : IChair
{
    public void HasLegs() => Console.WriteLine($"{nameof(VictorianChair)} has legs");
    public void SitOn() => Console.WriteLine($"Sit on {nameof(VictorianChair)}");
}


public class VictorianSofa : ISofa
{
    public void HasLegs() => Console.WriteLine($"{nameof(VictorianSofa)} has legs");
    public void SitOn() => Console.WriteLine($"Sit on {nameof(VictorianSofa)}");

}
public class VictorianCoffeeTable : ICoffeeTable
{
    public void IsRound() => Console.WriteLine($"{nameof(VictorianCoffeeTable)} is round");
    public void PlaceOn() => Console.WriteLine($"You placed {nameof(VictorianCoffeeTable)}");
}

public class ModernChair : IChair
{
    public void HasLegs() => Console.WriteLine($"{nameof(ModernChair)} hasn't legs");
    public void SitOn() => Console.WriteLine($"Sit on {nameof(ModernChair)}");
}

public class ModernSofa : ISofa
{
    public void HasLegs() => Console.WriteLine($"{nameof(ModernSofa)} hasn't legs");
    public void SitOn() => Console.WriteLine($"Sit on {nameof(ModernSofa)}");
}


public class ModernCoffeeTable : ICoffeeTable
{
    public void IsRound() => Console.WriteLine($"{nameof(ModernCoffeeTable)} is round");
    public void PlaceOn() => Console.WriteLine($"You placed {nameof(ModernCoffeeTable)}");
}



public class ArtDecoFurnitureFactory : FurnitureFactory
{
    public override IChair CreateChair() => new ArtDecoChair();
    public override ISofa CreateSofa() => new ArtDecoSofa();
    public override ICoffeeTable CreateCoffeeTable() => new ArtDecoCoffeeTable();

}

public class VictorianFurnitureFactory : FurnitureFactory
{
    public override IChair CreateChair() => new VictorianChair();
    public override ISofa CreateSofa() => new VictorianSofa();
    public override ICoffeeTable CreateCoffeeTable() => new VictorianCoffeeTable();
}

public class ModernFurnitureFactory : FurnitureFactory
{
    public override IChair CreateChair() => new ModernChair();
    public override ISofa CreateSofa() => new ModernSofa();
    public override ICoffeeTable CreateCoffeeTable() => new ModernCoffeeTable();
}


public class Program
{
    static void Main()
    {

        FurnitureFactory? furniture = null;
        while (true)
        {
            Console.WriteLine(@"
                            1: ArtDeco
                            2: Victorian
                            3: Modern
                            Any: Exit");

            Console.Write("\n\tEnter choice: ");

            furniture = Console.ReadLine() switch
            {
                "1" => new ArtDecoFurnitureFactory(),
                "2" => new VictorianFurnitureFactory(),
                "3" => new ModernFurnitureFactory(),
                _ => null
            };
            furniture.CreateChair().SitOn();
            furniture.CreateSofa().SitOn();
            furniture.CreateCoffeeTable().PlaceOn();

        }
    }
}