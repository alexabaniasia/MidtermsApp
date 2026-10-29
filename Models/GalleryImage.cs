namespace MidtermsApp.Models;

public enum GalleryTile
{
    Small,
    Wide,
    Feature
}

public class GalleryImage
{
    public int Id { get; init; }
    public string Src { get; init; } = "";
    public string Alt { get; init; } = "";
    public string Caption { get; init; } = "";
    public GalleryTile Tile { get; init; } = GalleryTile.Small;
}