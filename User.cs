namespace apbd_cw2_s33622;

public abstract class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Type { get; protected set; }
    public int MaxRental  { get; protected set; }

    public User(string name, string lastname)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        LastName = lastname;
    }
    
}