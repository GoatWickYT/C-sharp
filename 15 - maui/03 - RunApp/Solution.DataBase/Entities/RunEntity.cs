namespace Solution.Database.Entities;

[Table("Runner")]
public class RunEntity
{
    [Key]
    public uint Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public uint Distance { get; set; }

    [Required]
    public uint Time { get; set; }

    [Required]
    public double AverageSpeed { get; set; }

    [Required]
    public double BurnedCalories { get; set; }
}
