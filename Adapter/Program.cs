using System.Xml;
using System.Text.Json;
using System.Xml.Linq;
using System.Text.Json;
using System.Xml.Xsl;

namespace Adapter;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

}

public class FakeCustomers
{
    public List<Customer> GetCustomers =>
       new List<Customer> {
       new Customer { Id=1,Name = "Adam", Surname = "Johnson", Email = "adam.johnson@acme.com", Address = "IBM, 123 Fore Street" },
       new Customer { Id=2,Name = "Jacob", Surname = "Smith", Email = "jacob.smith@acme.com", Address = "IBM, ,123 Fore Street"},
    };
}

public class XmlReader
{
    public XDocument GetXML()
    {
        var xmlCustomer = new XDocument();
        var xElement = new XElement("Customers");
        var xAttributes = new FakeCustomers().GetCustomers
            .Select(customer => new XElement("Customers",
                                new XAttribute("Id", customer.Id),
                                new XAttribute("Name", customer.Name),
                                new XAttribute("Surname", customer.Surname),
                                new XAttribute("Email", customer.Email),
                                new XAttribute("Address", customer.Address)));

        xElement.Add(xAttributes);
        xmlCustomer.Add(xElement);

        Console.WriteLine(xmlCustomer);
        return xmlCustomer;
    }
}

public class JsonTransform
{
    private IEnumerable<Customer> _customer;

    public JsonTransform(IEnumerable<Customer> customers)
    {
        _customer = customers;
    }

    public object ConvertToJson()
    {
        var jsonCustomer = JsonSerializer.Serialize(_customer);

        Console.WriteLine($"JSON Conversion: \n {jsonCustomer}");
        return jsonCustomer;
    }
}
public interface IXMLtoJson
{
    object ConvertXmlToJson();
}

public class XmlToJsonAdapter : IXMLtoJson
{
    private readonly XmlReader _xmlConverter;

    public XmlToJsonAdapter(XmlReader xmlConverter)
    {
        _xmlConverter = xmlConverter;
    }

    public object ConvertXmlToJson()
    {
        var customers = _xmlConverter.GetXML()
                .Element("Customers")
                .Elements("Customers")
                .Select(Customer => new Customer
                {
                    Id = Convert.ToInt32(Customer.Attribute("Id").Value),
                    Name = Customer.Attribute("Name").Value,
                    Surname = Customer.Attribute("Surname").Value,
                    Email = Customer.Attribute("Email").Value,
                    Address = Customer.Attribute("Address").Value
                });

        var output = new JsonTransform(customers)
             .ConvertToJson();

        return output;
    }
}

class Program
{
    static void Main()
    {
        XmlReader reader = new();
        reader.GetXML();
        XmlToJsonAdapter adapter = new(reader);
        adapter.ConvertXmlToJson();
    }
}