using TarkovGeoGuesser.Models.Core;

namespace TarkovGeoGuesser.Models.DataProviders;

public class TarkovMapCollection
{
    public List<TarkovMap> Maps =>
        new List<TarkovMap>()
        {
            new TarkovMap("Factory", 20, 20),
            new TarkovMap("Shoreline", 20, 20),
            new TarkovMap("Woods", 20, 20)
        };
}