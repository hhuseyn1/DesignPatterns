namespace Proxy;

public class Employee
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    public Employee(string username, string password, string role)
    {
        Username = username;
        Password = password;
        Role = role;
    }
}

public interface ISharedFolder
{
    void PerformRWOperations();
}

public class SharedFolder : ISharedFolder
{
    //Simple guid
    public void PerformRWOperations()
    {
        Console.WriteLine("Performing Read/Write operation on the Shared Folder");
    }
}
class SharedFolderProxy : ISharedFolder //Proxy Class
{
    private ISharedFolder folder;
    private Employee employee;
    public SharedFolderProxy(Employee emp)
    {
        employee = emp;
    }
    public void PerformRWOperations()
    {
        //Does employee has access to the shared file
        if (employee.Role.ToUpper() == "CEO" || employee.Role.ToUpper() == "MANAGER")
        {
            folder = new SharedFolder();
            Console.WriteLine("Shared Folder Proxy makes call to the RealFolder 'PerformRWOperations method'");
            folder.PerformRWOperations();
        }
        else
        {
            Console.WriteLine("Shared Folder proxy says 'You don't have permission to access this folder'");
        }
    }
}

class Program
{
    static void Main()
    {
        Employee emp1 = new Employee("Huseyn", "Huseyn123", "Developer");
        SharedFolderProxy folderProxy1 = new SharedFolderProxy(emp1);
        folderProxy1.PerformRWOperations();
        Employee emp2 = new Employee("Huseyn1", "Huseyn1123", "Manager");
        SharedFolderProxy folderProxy2 = new SharedFolderProxy(emp2);
        folderProxy2.PerformRWOperations();
    }
}