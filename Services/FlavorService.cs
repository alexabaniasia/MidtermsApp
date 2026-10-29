using MidtermsApp.Models;

namespace MidtermsApp.Services;

public class FlavorService
{
    private static readonly IReadOnlyList<Flavor> Catalog = new List<Flavor>
    {
        new() { Id = 1, Name = "Blue Moo Cookie Monster", Category = "Specialty", Price = 7, IsFeatured = true,
                Description = "Bright blue vanilla cream packed with chocolate cookie chunks and a cookie crumble swirl.",
                ImageUrl = "/images/BlueMooCookieMonster.jpg", Tags = new[] { "Contains gluten" } },
        new() { Id = 2, Name = "Fresh Strawberry", Category = "Fruity", Price = 6, IsFeatured = true,
                Description = "Ripe summer strawberries churned into a smooth, naturally sweet cream base.",
                ImageUrl = "/images/strawberry.jpg", Tags = new[] { "Gluten-free" } },
        new() { Id = 3, Name = "Vanilla Bean", Category = "Classic", Price = 5, IsFeatured = true,
                Description = "Classic vanilla bean ice cream made from local dairy. Simple, creamy and timeless.",
                ImageUrl = "/images/vanilla_icecream.jpg", Tags = new[] { "Gluten-free" } },
        new() { Id = 4, Name = "Honeycomb Lavender", Category = "Specialty", Price = 6,
                Description = "Local honeycomb folded into a delicate lavender-infused sweet cream.",
                Tags = new[] { "Seasonal", "Gluten-free" } },
        new() { Id = 5, Name = "Mango Sorbet", Category = "Fruity", Price = 6,
                Description = "Sun-ripened mango blended with a squeeze of lime. Light and refreshing.",
                Tags = new[] { "Vegan", "Dairy-free" } },
        new() { Id = 6, Name = "Salted Caramel", Category = "Classic", Price = 6,
                Description = "Slow-cooked caramel ribboned through sweet cream with a pinch of sea salt.",
                Tags = new[] { "Gluten-free" } },
        new() { Id = 7, Name = "Mint Chip", Category = "Classic", Price = 6,
                Description = "Cool fresh mint cream studded with shaved dark chocolate.",
                Tags = new[] { "Gluten-free" } },
        new() { Id = 8, Name = "Dark Chocolate Truffle", Category = "Chocolate", Price = 7,
                Description = "Rich 70% dark cacao with house-made fudge ribbons and chocolate shavings.",
                Tags = new[] { "Gluten-free" } },
        new() { Id = 9, Name = "Brownie Batter", Category = "Chocolate", Price = 7,
                Description = "Chocolate cream swirled with fudgy brownie chunks.",
                Tags = new[] { "Contains gluten" } }
    };

    public IReadOnlyList<Flavor> GetAll() => Catalog;

    public IReadOnlyList<Flavor> GetFeatured() =>
        Catalog.Where(f => f.IsFeatured).ToList();

    public IReadOnlyList<string> GetNames() =>
        Catalog.Select(f => f.Name).OrderBy(n => n).ToList();

    public IReadOnlyList<IGrouping<string, Flavor>> GetMenuByCategory() =>
        Catalog.OrderBy(f => f.Name)
               .GroupBy(f => f.Category)
               .OrderBy(g => g.Key)
               .ToList();
}