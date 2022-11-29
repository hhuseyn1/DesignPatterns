using System.Data;

namespace Memento;

//Originator Class
public class Player
{
    public int Level;
    public int Score;
    public int Health;
    public int lifeline = 3;

    public Memento CreateMarker(Player player)
    {
        return new Memento(player.Level, player.Score, player.Health);
    }

    public void RestoreLevel(Memento playerMemento)
    {
        this.Level = playerMemento.Level;
        this.Score = playerMemento.Score;
        this.Health = playerMemento.Health;
        this.lifeline -= 1;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine("Level: " + this.Level);
        Console.WriteLine("Score: " + this.Score);
        Console.WriteLine("Health: " + this.Health);
        Console.WriteLine("Lifeline left: " + this.lifeline);
    }
}

//Memento class
public class Memento
{
    public int Level;
    public int Score;
    public int Health;

    public Memento(int level, int score, int health)
    {
        this.Level = level;
        this.Score = score;
        this.Health = health;
    }
}
//CareTaker class
public class CareTaker
{
    // store a checkpoint for already crossed level
    public Memento LevelMarker;
}
class Program
{
    static void Main()
    {
        Player player = new Player();//Player created
        player.Level = 1;
        player.Score = 100;
        player.Health = 100;
        Console.WriteLine("----------- Player info after completing level 1 ---------------------");
        player.DisplayPlayerInfo();
        CareTaker careTaker = new CareTaker();
        careTaker.LevelMarker = player.CreateMarker(player);//Checkpoint created
        Thread.Sleep(2000);//Delay 
        player.Level = 2;
        player.Score = 130;
        player.Health = 80;
        Console.WriteLine("--------------- Player info in level 2 --------------------------------");
        player.DisplayPlayerInfo();
        player.RestoreLevel(careTaker.LevelMarker);//Restore last checkpoint player info
        Console.WriteLine("------------- Player info after restoring level 1 data ----------------");
        player.DisplayPlayerInfo();


    }
}
