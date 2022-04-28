namespace TarkovGeoGuesser.Extensions;

public static class FormCollectionExtensions
{
    public static string? GetDifficulty(this IFormCollection fc)
    {
        if (!fc.Any(x => x.Key.StartsWith("diff_")))
            throw new Exception("Invalid difficulty selected!");
        else
        {
            return fc.Keys.FirstOrDefault(x => x.StartsWith("diff_"))?
                .Replace("diff_", "");
        }
    }
}