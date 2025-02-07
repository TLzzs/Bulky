using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    
    [Required]
    [MaxLength(20, ErrorMessage = "Name must be within 20 characters.") ]
    [DisplayName("Category Name")]
    public string Name { get; set; }
    
    [DisplayName("Display Order")]
    [Range(1, int.MaxValue, ErrorMessage = "Display Order must be greater than zero.")]
    public int DisplayOrder { get; set; }
}