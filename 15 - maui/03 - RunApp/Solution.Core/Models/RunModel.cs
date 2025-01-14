namespace Solution.Core.Models;

public class RunModel
{
    public uint Id { get; set; }

    public DateTime Date { get; set; }

    public ValidatableObject<uint> Distance { get; set; }

    public ValidatableObject<uint> Time { get; set; }

    public ValidatableObject<double> BurnedCalories { get; set; }

    public ValidatableObject<double> AverageSpeed { get; set; }

    public RunModel()
    {
        this.Date = new DateTime();
        this.Distance = new ValidatableObject<uint>();
        this.Time = new ValidatableObject<uint>();
        this.AverageSpeed = new ValidatableObject<double>();
        this.BurnedCalories = new ValidatableObject<double>();

        AddValidators();
    }

    public RunModel(RunEntity entity) : this()
    {
        Id = entity.Id;
        this.Date = entity.Date;
        Distance.Value = entity.Distance;
        Time.Value = entity.Time;
        AverageSpeed.Value = entity.Distance/entity.Time;
        BurnedCalories.Value = entity.BurnedCalories;
    }

    public RunEntity ToEntity()
    {
        return new RunEntity
        {
            Id = Id,
            Date = Date,
            Distance = Distance.Value,
            Time = Time.Value,
            AverageSpeed = Distance.Value / Time.Value,
            BurnedCalories = BurnedCalories.Value
        };
    }

    public void ToEntity(RunEntity entity)
    {
        entity.Id = Id;
        entity.Date = Date;
        entity.Distance = Distance.Value;
        entity.Time = Time.Value;
        entity.AverageSpeed = Distance.Value / Time.Value;
        entity.BurnedCalories = BurnedCalories.Value;
    }

    private void AddValidators()
    {
        Time.Validations.Add(new NullableIntegerRule<uint> { ValidationMessage = "Run time is required." });
        Time.Validations.Add(new MinValueRule<uint>(0) { ValidationMessage = "Run time must be greater than 0."});

        Distance.Validations.Add(new IsNotNullOrEmptyRule<uint> { ValidationMessage = "Distance is required." });
        Distance.Validations.Add(new NullableIntegerRule<uint> { ValidationMessage = "Distance is required." });
        Distance.Validations.Add(new MinValueRule<uint>(0) { ValidationMessage = "Distance must be greater than 0." });

        BurnedCalories.Validations.Add(new NullableDoubleRule<double> { ValidationMessage = "Burned calories is required." });
        BurnedCalories.Validations.Add(new MinValueRule<double>(0) { ValidationMessage = "Burned calories must be greater than 0." });
    }
}
