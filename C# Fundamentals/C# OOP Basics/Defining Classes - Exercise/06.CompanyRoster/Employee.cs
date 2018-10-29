
public class Employee
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    private string position;

    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    private string departm;

    public string Departm
    {
        get { return departm; }
        set { departm = value; }
    }

    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }


    public Employee(string name, decimal salary, string position, string departm, string email, int age)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Departm = departm;
        this.Email = email;
        this.Age = age;

    }
}