namespace apbd_cw2_s33622;

public abstract class Equipment

{
    public string Id { get; private set; }
    public string Name { get; set; }
    public bool Available { get; set; }

    public Equipment(string name)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Available = true;
    }
}