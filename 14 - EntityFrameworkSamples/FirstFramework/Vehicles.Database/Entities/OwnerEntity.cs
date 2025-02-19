namespace Vehicles.Database.Entities;

[Table("Owner")]
[Index(nameof(TAJ), IsUnique = true)]

public class OwnerEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public DateTime Birthday { get; set; }

    [Required]
    [StringLength(50)]
    public string TAJ { get; set; }

    [ForeignKey("Street")]
    public uint StreetId { get; set; }

    public virtual StreetEntity Street { get; set; }

    public virtual IReadOnlyCollection<VehicleEntity> Vehicles { get; set; }
}