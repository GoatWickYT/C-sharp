namespace Vehicles.Database.Entities;

[Table("Street")]
public class StreetEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [ForeignKey("City")]
    public uint CityPostalCode { get; set; }

    public virtual CityEntity City { get; set; }
}