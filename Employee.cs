namespace apbd_cw2_s33622;

public class Employee : User
{
    public Employee(string name, string lastname) : base(name, lastname)
    {
        Type = "Employee";
        MaxRental = 5;
    }
}