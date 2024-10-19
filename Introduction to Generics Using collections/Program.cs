using System;
using System.Collections.Generic;
using System.Linq;


//Task 1
class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public string CorporateEmail { get; set; }
}

class EmployeeManagement
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public void RemoveEmployee(string email)
    {
        employees.RemoveAll(e => e.CorporateEmail == email);
    }

    public void UpdateEmployee(Employee updatedEmployee)
    {
        var employee = employees.FirstOrDefault(e => e.CorporateEmail == updatedEmployee.CorporateEmail);
        if (employee != null)
        {
            employee.FullName = updatedEmployee.FullName;
            employee.Position = updatedEmployee.Position;
            employee.Salary = updatedEmployee.Salary;
        }
    }

    public Employee FindEmployeeByEmail(string email)
    {
        return employees.FirstOrDefault(e => e.CorporateEmail == email);
    }

    public IEnumerable<Employee> SortEmployeesBySalary()
    {
        return employees.OrderBy(e => e.Salary);
    }
}


//Task 2
class PasswordManagement
{
    private Dictionary<string, string> credentials = new Dictionary<string, string>();

    public void AddCredentials(string login, string password)
    {
        credentials[login] = password;
    }

    public void RemoveCredentials(string login)
    {
        credentials.Remove(login);
    }

    public void UpdateCredentials(string login, string newPassword)
    {
        if (credentials.ContainsKey(login))
        {
            credentials[login] = newPassword;
        }
    }

    public string GetPasswordByLogin(string login)
    {
        return credentials.ContainsKey(login) ? credentials[login] : null;
    }
}


//Task 3
class CafeQueue
{
    private Queue<string> regularQueue = new Queue<string>();
    private Queue<string> reservedQueue = new Queue<string>();

    public void AddToQueue(string customer, bool isReserved)
    {
        if (isReserved)
        {
            reservedQueue.Enqueue(customer);
        }
        else
        {
            regularQueue.Enqueue(customer);
        }
    }

    public string GetNextCustomer()
    {
        if (reservedQueue.Count > 0)
        {
            return reservedQueue.Dequeue();
        }
        else if (regularQueue.Count > 0)
        {
            return regularQueue.Dequeue();
        }
        return null;
    }
}


class Program
{
    //Task 1
    static void Main()
    {
        var management = new EmployeeManagement();

        management.AddEmployee(new Employee { FullName = "Ryan Gosling", Position = "Manager", Salary = 600000, CorporateEmail = "RyanGosling@example.com" });
        management.AddEmployee(new Employee { FullName = "John Harris", Position = "Developer", Salary = 350000, CorporateEmail = "JohnHarris@example.com" });

        Console.WriteLine("Added Employees:");
        foreach (var emp in management.SortEmployeesBySalary())
        {
            Console.WriteLine($"{emp.FullName}, {emp.Position}, {emp.Salary}, {emp.CorporateEmail}");
        }

        Console.WriteLine("\nUpdating Ryan Gosling's Salary...");
        management.UpdateEmployee(new Employee { FullName = "Ryan Gosling", Position = "Manager", Salary = 65000, CorporateEmail = "RyanGosling@example.com" });

        Console.WriteLine("\nEmployees after update:");
        foreach (var emp in management.SortEmployeesBySalary())
        {
            Console.WriteLine($"{emp.FullName}, {emp.Position}, {emp.Salary}, {emp.CorporateEmail}");
        }


        //Task 2
        var passwordManager = new PasswordManagement();

        passwordManager.AddCredentials("Ryan Gosling", "123456789");
        passwordManager.AddCredentials("John Harris", "qwerty");

        Console.WriteLine($"Password for Ryan Gosling: {passwordManager.GetPasswordByLogin("Ryan Gosling")}");

        Console.WriteLine("\nUpdating John Harris password...");
        passwordManager.UpdateCredentials("John Harris", "123456789qwerty");

        Console.WriteLine($"Password for John Harris: {passwordManager.GetPasswordByLogin("John Harris")}");


        //Task 3
        var cafeQueue = new CafeQueue();

        cafeQueue.AddToQueue("First customer", false);
        cafeQueue.AddToQueue("Second customer", true);
        cafeQueue.AddToQueue("Third customer", false);

        Console.WriteLine($"Next customer: {cafeQueue.GetNextCustomer()}");
        Console.WriteLine($"Next customer: {cafeQueue.GetNextCustomer()}");
        Console.WriteLine($"Next customer: {cafeQueue.GetNextCustomer()}");
    }
}