using MidtermsApp.Models;

namespace MidtermsApp.Services;

public class GalleryService
{
    private static readonly IReadOnlyList<GalleryImage> Images = new List<GalleryImage>
    {
        new() { Id = 1, Src = "/images/shop.jpg", Alt = "Inside the Milk & Meadow parlor",
                Caption = "Our parlor, open daily", Tile = GalleryTile.Feature },
        new() { Id = 2, Src = "/images/IceCreamCones.jpg", Alt = "Ice cream cones",
                Caption = "Scooped to order, every cone" },
        new() { Id = 3, Src = "/images/strawberry.jpg", Alt = "Strawberry ice cream",
                Caption = "Fresh Strawberry" },
        new() { Id = 4, Src = "/images/vanilla_icecream.jpg", Alt = "Vanilla ice cream",
                Caption = "Vanilla Bean" },
        new() { Id = 5, Src = "/images/BlueMooCookieMonster.jpg", Alt = "Blue Moo Cookie Monster ice cream",
                Caption = "Blue Moo Cookie Monster", Tile = GalleryTile.Wide }
    };

    public IReadOnlyList<GalleryImage> GetAll() => Images;
}