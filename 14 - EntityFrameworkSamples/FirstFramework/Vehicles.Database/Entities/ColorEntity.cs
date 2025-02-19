namespace Vehicles.Database.Entities;

[Table("Color")]
[Index(nameof(Code), nameof(Name), IsUnique = true)]

public class ColorEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(6)]
    public string Code { get; set; }

    [Required]
    [StringLength(30)]
    public string Name { get; set; }
    // University of Pennsylvania red

    public virtual IReadOnlyCollection<VehicleEntity> Vehicles { get; set; } // nav property

    override public string ToString()
    {
        return $"{Name} (#{Code})";
    }
}
