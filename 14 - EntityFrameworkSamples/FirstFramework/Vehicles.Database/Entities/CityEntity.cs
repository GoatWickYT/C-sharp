namespace Vehicles.Database.Entities;

[Table("City")]
public class CityEntity
{
    [Key]
    [Range(1000, 9999)]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public uint PostalCode { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public virtual IReadOnlyCollection<StreetEntity> Streets { get; set; }
}
