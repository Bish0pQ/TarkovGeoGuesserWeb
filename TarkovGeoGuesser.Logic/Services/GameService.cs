using TarkovGeoGuesser.Logic.Interfaces;
using TarkovGeoGuesser.Models.DataProviders;

namespace TarkovGeoGuesser.Logic.Services;

public class GameService : IGameService
{
    private readonly TarkovMapCollection _tarkovMaps;
    private readonly Random _rnd;
    
    public GameService()
    {
        _tarkovMaps = new TarkovMapCollection();
        _rnd = new Random();
    }
    
    public string CreateNew(string mapName, string contentPath)
    {
        // TODO: Get the actual map object
        var selectedMap = _tarkovMaps.Maps.FirstOrDefault(x => x.Name.ToLower() == mapName);
        if (selectedMap == null) throw new Exception($"Map with name {mapName} is not found in the map collection.");
        
        // Get the correct folder structure
        var fullPath = Path.Combine(contentPath, "img", "game", mapName.ToLower());
        if (!Directory.Exists(fullPath)) throw new Exception($"Images for the map {mapName} are missing.");
        
        // Get all available files in the folder
        var possibleImages = Directory.GetFiles(fullPath);
        if (possibleImages == null || possibleImages.Length < 1)
            throw new Exception($"No images found in directory {fullPath} or no access to the images was provided.");

        // Select a random image (path)
        var randomImage = possibleImages[_rnd.Next(0, possibleImages.Length)];
        return randomImage;
    }
}