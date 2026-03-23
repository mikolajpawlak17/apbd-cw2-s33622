namespace apbd_cw2_s33622;

public class Laptop : Equipment
{
    public string Processor{get; set; }
    public int ScreenSize { get; set; }

    public Laptop(string name, string processor, int screenSize): base(name)
    {
        Processor = processor;
        ScreenSize = screenSize;
        
    }
}