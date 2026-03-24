namespace apbd_cw2_s33622;

public class Service
{
    public List<User> Users { get; set; }
    public List<Equipment> Equipments { get; set; }
    public List<Rental> Rentals { get; set; }

    public void Rent(string userId, string equipmentId)
    {
        var user = Users.FirstOrDefault(u => u.Id == userId);
        var equipment = Equipments.FirstOrDefault(e => e.Id == equipmentId);
        if (user == null || equipment == null)
        {
            Console.WriteLine("Błąd, nie znaleziono użytkownika lub sprzętu");
        }

        if (!equipment.Available)
        {
            Console.WriteLine($"Błąd: {equipment.Name} jest obecnie wypożyczony.");
        }
        
        int activeRent = Rentals.Count(r => r.User.Id == userId && r.ReturnDate == null);
        if (activeRent > user.MaxRental)
        {
            Console.WriteLine($"Błąd: Użytkownik {user.Name} przekroczył limit wypożyczonego sprzętu: ({user.MaxRental}).");
        }
        
        var newRent = new Rental(user, equipment);
        Rentals.Add(newRent);
        equipment.Available = false;
        
        Console.WriteLine($"Użytkownik: {user.Name} wypożyczył {equipment.Name}.");
        
    }
    
    public void Return(string equipmentId)
    {
        var rental = Rentals.FirstOrDefault(r => r.Equipment.Id == equipmentId && r.ReturnDate == null);

        if (rental == null)
        {
            Console.WriteLine("Błąd: Nie znaleziono aktywnego wypożyczenia dla tego sprzętu.");
        }
        rental.ReturnDate =  DateTime.Now;
        rental.Equipment.Available = true;

        double penalty = rental.Penalty();
        if (penalty > 0)
        {
            Console.WriteLine($"Sprzęt zwrócony z opóźnieniem. Kara wynosi : {penalty} zł.");
        }
        else
        {
            Console.WriteLine("Sprzęt zwrócony w terminie.");
        }
    }
    
}