namespace WebApplication2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Component
{
    [Key]
    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    public string Code { get; set; } = null!;
    [Required, MaxLength(300)]
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
        
    public int ComponentManufacturerId { get; set; }
    [ForeignKey(nameof(ComponentManufacturerId))]
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;

    public int ComponentTypeId { get; set; }
    [ForeignKey(nameof(ComponentTypeId))]
    public ComponentType ComponentType { get; set; } = null!;

    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}