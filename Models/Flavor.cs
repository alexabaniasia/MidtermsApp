namespace MidtermsApp.Models;

public class Flavor
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public string Description { get; init; } = "";
    public string Category { get; init; } = "Classic";
    public decimal Price { get; init; }
    public string? ImageUrl { get; init; }
    public string[] Tags { get; init; } = Array.Empty<string>();
    public bool IsFeatured { get; init; }
}