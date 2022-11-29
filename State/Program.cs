namespace State;

public interface IPlaystation
{
    void X();
    void D();//Square
    void O();
    void T();//Triangle

}

public class BallOpposite : IPlaystation
{

    public void O()
    {
        Console.WriteLine("Selected player is sliding");
    }

    public void T()
    {
        Console.WriteLine("Gk is coming");
    }

    public void X()
    {
        Console.WriteLine("Selected player is pressing");
    }

    public void D()
    {
        Console.WriteLine("Team players are too pressing");
    }
}

public class BallYou : IPlaystation
{
    public void O()
    {
        Console.WriteLine("Ball cross center");
    }

    public void T()
    {
        Console.WriteLine("Through ball");
    }

    public void X()
    {
        Console.WriteLine("Pass ball to nearly player");
    }

    public void D()
    {
        Console.WriteLine("Shot to kickboard");
    }
}

class Program
{
    static void Main()
    {
        IPlaystation playstation = new BallOpposite();
        playstation.X();
        playstation.D();
        playstation.O();
        playstation.T();
        IPlaystation playstation2 = new BallYou();
        playstation2.X();
        playstation2.D();
        playstation2.O();
        playstation2.T();

    }
}