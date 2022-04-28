namespace TarkovGeoGuesser.Models.Core;

public class TarkovMap
{
    public TarkovMap(string name, int x, int y)
    {
        this.Name = name;
        this.TopXCoordinate = x;
        this.TopYCoordinate = y;
    } 
    
    public TarkovMap()
    {
    }

    public string Name { get; set; }
    public int TopXCoordinate { get; set; }
    public int TopYCoordinate { get; set; }
}