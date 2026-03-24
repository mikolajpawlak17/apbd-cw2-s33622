namespace apbd_cw2_s33622;

public class Rental
{
    public string RentalId { get; private set; }
    public User User { get; private set; }
    public Equipment Equipment { get; private set; }
    public DateTime RentalDate { get; private set; }
    public DateTime RentalEndDate { get; private set; }
    public DateTime? ReturnDate { get; set; }
    
    public Rental(User user, Equipment equipment)
        {
        RentalId = Guid.NewGuid().ToString();
        User = user;
        Equipment = equipment;
        RentalDate = DateTime.Now;
        RentalEndDate = RentalDate.AddDays(7);
        ReturnDate = null;
        }

    public double Penalty()
    {
        DateTime dateCheck = ReturnDate.GetValueOrDefault(DateTime.Now);
        if (dateCheck > RentalEndDate)
        {
            var delay = (dateCheck - RentalEndDate).TotalDays;
            return delay*5.0;
        }
        return 0.0;
    }
}