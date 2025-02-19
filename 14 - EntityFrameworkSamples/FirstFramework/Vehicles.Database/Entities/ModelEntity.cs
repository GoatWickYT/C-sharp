namespace Vehicles.Database.Entities;

[Table("Model")]
[Index(nameof(Name), IsUnique = true)]

public class ModelEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [ForeignKey("Manufacturer")]
    public uint ManufacturerId { get; set; }

    public virtual ManufacturerEntity Manufacturer { get; set; }

    public virtual IReadOnlyCollection<VehicleEntity> Vehicles { get; set; }
}