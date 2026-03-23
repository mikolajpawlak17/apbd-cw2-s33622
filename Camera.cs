namespace apbd_cw2_s33622;

public class Camera : Equipment
{
    public string Resolution { get; set; }
    public string ZoomType { get; set; }
    
    public Camera(string name, string resolution, string zoomType): base(name)
    {
        Resolution = resolution;
        ZoomType = zoomType;
    }
}