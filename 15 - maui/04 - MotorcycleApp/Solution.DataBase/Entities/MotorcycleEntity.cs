namespace Solution.Database.Entities;

[Table("Motorcycle")]
public class MotorcycleEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(128)]
    public string PublicId { get; set; }

    [Required]
    [StringLength(128)]
    public string Model { get; set; }

    [Required]
    public uint CubicCentimeters { get; set; }

    [Required]
    public uint ReleaseYear { get; set; }

    [Required]
    public uint CylinderNumber { get; set; }

    [ForeignKey("Manufacturer")]
    public uint ManufacturerId { get; set; }
    public virtual ManufacturerEntity Manufacturer { get; set; }
}
