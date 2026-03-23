namespace apbd_cw2_s33622;

public class Student : User
{
    public Student(string name, string lastname) : base(name, lastname)
    {
        Type = "Student";
        MaxRental = 2;
    }
}