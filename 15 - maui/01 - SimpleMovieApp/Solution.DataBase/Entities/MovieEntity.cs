namespace Solution.Database.Entities;

[Table("Movie")]
[Index(nameof(PublicId), IsUnique = true)]
public class MovieEntity
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public uint Id { get; set; }

	[Required]
	[StringLength(64)]
	public string PublicId { get; set; }

	[Required]
	[StringLength(128)]
	public string Title { get; set; }

	[Required]
	public uint Length { get; set; }

	[Required]
	public DateTime Release {  get; set; }
}
