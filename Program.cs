namespace apbd_cw2_s33622;

public class Program
{
    public static void Main(string[] args)
    {
        var service =  new Service();

        var s1 = new Student("Michał", "Kwiatkowski");
        var e1 = new Employee("Adam", "Lipski");
        
        service.Users.Add(s1);
        service.Users.Add(e1);
        
        var l1 = new Laptop("MacBook Pro", "M2", 14);
        var l2 = new Laptop("Lenovo Yoga", "i7", 15);
        var c1 = new Camera("Sony A7", "4K", "Optical");
        var p1 = new Projector("Epson EB", "3000", true);
        
        service.Equipments.Add(l1);
        service.Equipments.Add(l2);
        service.Equipments.Add(c1);
        service.Equipments.Add(p1);
        
        service.Rent(s1.Id, l1.Id); 
        service.Rent(s1.Id, l2.Id); 
        service.Rent(s1.Id, c1.Id); 
        
        service.Rent(e1.Id, l1.Id);
        
        service.Return(l1.Id);       
        service.Rent(e1.Id, l1.Id);
        
        service.DisplayRentals();
    }
}