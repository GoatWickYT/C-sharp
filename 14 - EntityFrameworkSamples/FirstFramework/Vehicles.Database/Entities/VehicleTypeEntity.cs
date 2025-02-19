namespace Vehicles.Database.Entities;

[Table("Type")]
[Index(nameof(Name), IsUnique = true)]

public class VehicleTypeEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public virtual ICollection<VehicleEntity> Vehicles { get; set; }
}
