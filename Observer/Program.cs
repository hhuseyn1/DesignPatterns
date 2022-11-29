namespace Observer;

public class Subject : ISubject
{
    private List<Observer> observers = new List<Observer>();
    private int _int;
    public int Inventory
    {
        get
        {
            return _int;
        }
        set
        {
            if (value > _int)
                Notify();
            _int = value;
        }
    }
    public void Subscribe(Observer observer)
    {
        observers.Add(observer);
        Console.WriteLine($"{observer.ObserverName} is subscribed");
    }

    public void Unsubscribe(Observer observer)
    {
        observers.Remove(observer);
        Console.WriteLine($"{observer.ObserverName} is unsubscribed");
    }

    public void Notify()
    {
        observers.ForEach(x => x.Update());
    }
}

interface ISubject
{
    void Subscribe(Observer observer);
    void Unsubscribe(Observer observer);
    void Notify();
}

public class Observer : IObserver
{
    public string ObserverName { get; private set; }
    public Observer(string name)
    {
        this.ObserverName = name;
    }
    public void Update()
    {
        Console.WriteLine($"{this.ObserverName}: A new product has arrived at the store");
    }
}

interface IObserver
{
    void Update();
}
class Program
{
    static void Main()
    {
        Subject subject = new Subject();
        Observer observer1 = new Observer("Observer 1");
        Observer observer2 = new Observer("Observer 2");
        Observer observer3 = new Observer("Observer 3");
        subject.Subscribe(observer1);
        subject.Subscribe(observer2);//Observers subscribe
        subject.Subscribe(observer3);
        subject.Inventory++;
        subject.Unsubscribe(observer1);//Observer unsubscribe
        subject.Inventory++;
    }
}