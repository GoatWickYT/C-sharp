namespace Vehicles.Database.Entities;

[Table("Vehicle")]
[Index(nameof(LisencePlate), IsUnique = true)]


public class VehicleEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(7)]
    public string LisencePlate { get; set; }

    [Required]
    [StringLength(17)]
    public string ChassisNumber { get; set; }

    [Required]
    [StringLength(2)]
    public string EngineNumber { get; set; }

    [Required]
    [Range(2,6)]
    public uint NumberOfDoors { get; set; }

    [Required]
    public uint Weight { get; set; }

    [Required]
    public uint Power { get; set; }

    [ForeignKey("Color")]
    public uint ColorId { get; set; }

    public virtual ColorEntity Color { get; set; }
    
    [ForeignKey("Model")]
    public uint ModelId { get; set; }

    public virtual ModelEntity Model { get; set; }

    [ForeignKey("Usage")]
    public uint UsageID { get; set; }

    public virtual VehicleUsageEntity VehicleUsage { get; set; }

    [ForeignKey("Type")]
    public uint TypeId { get; set; }

    public virtual VehicleTypeEntity VehicleType { get; set; }

    [ForeignKey("Owner")]
    public uint OwnerId { get; set; }

    public virtual OwnerEntity Owner { get; set; }
}