namespace apbd_cw2_s33622;

public class Service
{
    public List<User> Users { get; set; } = new();
    public List<Equipment> Equipments { get; set; } = new();
    public List<Rental> Rentals { get; set; } = new();

    public void Rent(string userId, string equipmentId)
    {
        var user = Users.FirstOrDefault(u => u.Id == userId);
        var equipment = Equipments.FirstOrDefault(e => e.Id == equipmentId);
        if (user == null || equipment == null)
        {
            Console.WriteLine("Błąd, nie znaleziono użytkownika lub sprzętu");
            return;
        }

        if (!equipment.Available)
        {
            Console.WriteLine($"Błąd: {equipment.Name} jest obecnie wypożyczony.");
            return;
        }
        
        int activeRent = Rentals.Count(r => r.User.Id == userId && r.ReturnDate == null);
        if (activeRent >= user.MaxRental)
        {
            Console.WriteLine($"Błąd: Użytkownik {user.Name} przekroczył limit wypożyczonego sprzętu: ({user.MaxRental}).");
            return;
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
            return;
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
    
    public void DisplayRentals()
    {
        foreach (var rental in Rentals)
        {
            var status = rental.ReturnDate.HasValue ? 
                $"zwrócono dnia: {rental.ReturnDate}" 
                : $"wypożyczone, termin zwrotu to : {rental.RentalEndDate}";
            Console.WriteLine($"Użytkownik: {rental.User.Name} {rental.User.LastName} wypożyczył: {rental.Equipment.Name}. Status: {status} | Kara wynosi: {rental.Penalty()} PLN");
        }
    }
    
}