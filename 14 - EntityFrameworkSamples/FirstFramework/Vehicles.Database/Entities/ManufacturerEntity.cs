namespace Vehicles.Database.Entities;

[Table("Manufacturer")]
[Index(nameof(Name), IsUnique = true)]

public class ManufacturerEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(2)]
    public string ISOCountryCode { get; set; }

    public virtual IReadOnlyCollection<ModelEntity> Models { get; set; }
}