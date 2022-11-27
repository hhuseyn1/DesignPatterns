using System.Collections;

namespace Iterator;

struct Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}

interface IAggregate
{
    IIterator CreateIterator();
}

interface IIterator
{
    bool HasItem();
    Employee NextItem();
    Employee CurrentItem();
    void Reset();
}

class EmployeeAggregate : IAggregate
{
    List<Employee> Employees = new List<Employee>();
    public void Add(Employee Model) => Employees.Add(Model);
    public Employee GetItem(int index) => Employees[index];
    public int Count { get => Employees.Count; }
    public IIterator CreateIterator() => new EmployeeIterator(this);
}


class EmployeeIterator : IIterator
{
    EmployeeAggregate aggregate;
    int currentindex;
    public EmployeeIterator(EmployeeAggregate aggregate) => this.aggregate = aggregate;
    public Employee CurrentItem() => aggregate.GetItem(currentindex);
    public bool HasItem()
    {
        if (currentindex < aggregate.Count)
            return true;
        return false;
    }
    public Employee NextItem()
    {
        if (HasItem())
            return aggregate.GetItem(currentindex++);
        return new Employee();
    }

    public void Reset()
    {
        currentindex = 0;
    }
}

class Program
{

    static void Main()
    {
        EmployeeAggregate aggregate = new EmployeeAggregate();
        aggregate.Add(new Employee { Id = 1, Name = "Gençay", Surname = "Yıldız" });
        aggregate.Add(new Employee { Id = 2, Name = "Ahmet", Surname = "Çakmak" });
        aggregate.Add(new Employee { Id = 3, Name = "Huseyn", Surname = "Hemidov" });
        aggregate.Add(new Employee { Id = 4, Name = "Emin", Surname = "Novruz" });

        IIterator iterator = aggregate.CreateIterator();
        while (iterator.HasItem())
        {
            Console.WriteLine($"ID : {iterator.CurrentItem().Id}\nName : {iterator.CurrentItem().Name}\nSurname : {iterator.CurrentItem().Surname}\n*****");
            iterator.NextItem();
        }
        iterator.Reset();
        while (iterator.HasItem())
        {
            Console.WriteLine($"ID : {iterator.CurrentItem().Id}\nName : {iterator.CurrentItem().Name}\nSurname : {iterator.CurrentItem().Surname}\n*****");
            iterator.NextItem();
        }
        //Console.WriteLine(iterator.HasItem());

    }
}