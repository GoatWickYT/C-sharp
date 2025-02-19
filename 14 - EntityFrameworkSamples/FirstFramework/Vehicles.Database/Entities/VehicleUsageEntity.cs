namespace Vehicles.Database.Entities;

[Table("Usage")]
[Index(nameof(Name), IsUnique = true)]

public class VehicleUsageEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Name { get; set; }

    public virtual IReadOnlyCollection<VehicleEntity> Vehicles { get; set; }

}
