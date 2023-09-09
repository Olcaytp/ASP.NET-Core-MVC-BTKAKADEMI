using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public record ProductDto
{
    public int ProductId { get; init; }

    [Required(ErrorMessage = "Product name is required")]
    public string? ProductName { get; init; } = String.Empty;

    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; init; }

    public int? CategoryId { get; init; } 


}