using System;

static void Main(string[] args)
{
Start:
Console.Write("Enter Name: ");
string name = Console.ReadLine();
string apiUrl = "https://localhost:44374/api/CustomerAPI";
var input = new
{
Name = name,
};
string inputJson = (new JavaScriptSerializer()).Serialize(input);
WebClient client = new WebClient();
client.Headers["Content-type"] = "application/json";
client.Encoding = Encoding.UTF8;
string json = client.UploadString(apiUrl + "/GetCustomers", inputJson);
List<Customer> customers = (new JavaScriptSerializer()).Deserialize<List<Customer>>(json);
if (customers.Count > 0)
{
foreach (Customer customer in customers)
{
Console.WriteLine(customer.ContactName);
}
}
else
{
Console.WriteLine("No records found.");
}
Console.WriteLine();
goto Start;
}

public class Customer
{
    public string CustomerID { get; set; }
    public string ContactName { get; set; }
    public string City { get; set; }
}
