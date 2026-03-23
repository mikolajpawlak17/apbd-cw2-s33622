namespace apbd_cw2_s33622;

public class Projector : Equipment
{
    public string Brightness { get; set; }
    public bool Is4K { get; set; }

    public Projector(string name, string brightness, bool is4K) : base(name)
    {
        Brightness = brightness;
        Is4K = is4K;
    }
}