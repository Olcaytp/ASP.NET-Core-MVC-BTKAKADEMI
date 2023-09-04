using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product name is required")]
    public string? ProductName { get; set; } = String.Empty;

    [Required(ErrorMessage = "Priice is required")]
    public decimal Price { get; set; }

}
