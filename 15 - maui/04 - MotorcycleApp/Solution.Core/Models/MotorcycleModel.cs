namespace Solution.Core.Models;

public partial class MotorcycleModel
{
    public string Id { get; set; }
    public ValidatableObject<uint> ManufacturerId { get; set; }
    public ValidatableObject<string> Model { get; protected set; }
    public ValidatableObject<uint?> CubicCentimeters { get; protected set; }
    public ValidatableObject<uint?> ReleaseYear { get; protected set; }
    public ValidatableObject<uint?> CylinderNumber { get; protected set; }

    public MotorcycleModel()
    {
        this.Model = new ValidatableObject<string>();
        this.ManufacturerId = new ValidatableObject<uint>();
        this.CubicCentimeters = new ValidatableObject<uint?>();
        this.ReleaseYear = new ValidatableObject<uint?>();
        this.CylinderNumber = new ValidatableObject<uint?>();

        AddValidators();
    }


    public MotorcycleModel(MotorcycleEntity entity): this()
    {
        this.Id = entity.PublicId;
        this.ManufacturerId.Value = entity.ManufacturerId;
        this.Model.Value = entity.Model;
        this.CubicCentimeters.Value = entity.CubicCentimeters;
        this.ReleaseYear.Value = entity.ReleaseYear;
        this.CylinderNumber.Value = entity.CylinderNumber;
    }

    public MotorcycleEntity ToEntity()
    {
        return new MotorcycleEntity
        {
            PublicId = this.Id,
            ManufacturerId = this.ManufacturerId.Value,
            Model = this.Model.Value,
            CubicCentimeters = this.CubicCentimeters.Value ?? 0,
            ReleaseYear = this.ReleaseYear.Value ?? 0,
            CylinderNumber = this.CylinderNumber.Value ?? 0
        };
    }

    public void ToEntity(MotorcycleEntity entity)
    {
        entity.PublicId = this.Id;
        entity.ManufacturerId = this.ManufacturerId.Value;
        entity.Model = this.Model.Value;
        entity.CubicCentimeters = this.CubicCentimeters.Value ?? 0;
        entity.ReleaseYear = this.ReleaseYear.Value ?? 0;
        entity.CylinderNumber = this.CylinderNumber.Value ?? 0;
    }

    private void AddValidators()
    {
        this.Model.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Model is required"});

        this.CubicCentimeters.Validations.AddRange([
            new NullableIntegerRule<uint?> { ValidationMessage = "Cubic Centimeters is required" },
            new MinValueRule<uint?>(1) { ValidationMessage = "Cubic Centimeters must be greater than 0" },
            new MaxValueRule<uint?>(1800) { ValidationMessage = "Cubic Centimeters must be less than or equal to 1800" }
        ]);

        this.ReleaseYear.Validations.AddRange([
            new NullableIntegerRule<uint?> { ValidationMessage = "Release Year is required" },        
            new MaxValueRule<uint?>(DateTime.Now.Year) { ValidationMessage = $"Release Year must be less than or equal to the current year ({DateTime.Now})"},        
            new MinValueRule<uint?>(1885) { ValidationMessage = "Release Year must be less than or equal to 1885"}
        ]);

        this.CylinderNumber.Validations.Add(new NullableIntegerRule<uint?> { ValidationMessage = "Cylinder Number is required" });

        this.ManufacturerId.Validations.Add(new MinValueRule<uint>(0) { ValidationMessage = "Manufacturer must be selected" });
    }
}
