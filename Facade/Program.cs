namespace Facade;

public class Product
{
    public void GetProductDetails()
    {
        Console.WriteLine("Product details");
    }
}

public class Payment
{
    public void MakePayment()
    {
        Console.WriteLine("Payment successfully");
    }
}

public class Invoice
{
    public void Sendinvoice()
    {
        Console.WriteLine("Invoice successfully");
    }
}
public class OrderFacade
{
    private Product _product = new();
    private Payment _payment = new();
    private Invoice _invoice = new();
    public void PlaceOrder()
    {
        Console.WriteLine("Place order started");
        _product.GetProductDetails();
        _payment.MakePayment();
        _invoice.Sendinvoice();
        Console.WriteLine("Order placed successfully");
    }
}


class Program
{
    static void Main()
    {
        OrderFacade order = new OrderFacade();
        order.PlaceOrder();
    }
}