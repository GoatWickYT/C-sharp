namespace Solution.Core.Models;

public partial class MotorcycleModel
{
    public string Id { get; set; }

    public string ImageId { get; set; }

    public string WebContentLink { get; set; }

    public ValidatableObject<ManufacturerModel> Manufacturer { get; set; }

    public ValidatableObject<TypeModel> Type { get; set; }

    public ValidatableObject<string> Model { get; protected set; }

    public ValidatableObject<uint?> Cubic { get; protected set; }

    public ValidatableObject<uint?> ReleaseYear { get; protected set; }

    public ValidatableObject<uint?> CylindersNumber { get; protected set; }

    public MotorcycleModel()
    {
        this.Manufacturer = new ValidatableObject<ManufacturerModel>();
        this.Type = new ValidatableObject<TypeModel>();
        this.Model = new ValidatableObject<string>();
        this.Cubic = new ValidatableObject<uint?>();
        this.ReleaseYear = new ValidatableObject<uint?>();
        this.CylindersNumber = new ValidatableObject<uint?>();

        AddValidators();
    }

    public MotorcycleModel(MotorcycleEntity entity): this()
    {
        this.Id = entity.PublicId;
        this.Manufacturer.Value = new ManufacturerModel(entity.Manufacturer);
        this.Type.Value = new TypeModel(entity.Type);
        this.Model.Value = entity.Model;
        this.Cubic.Value = entity.Cubic;
        this.ReleaseYear.Value = entity.ReleaseYear;
        this.CylindersNumber.Value = entity.Cylinders;
        this.ImageId = entity.ImageId;
        this.WebContentLink = entity.WebContentLink;
    }

    public MotorcycleEntity ToEntity()
    {
        return new MotorcycleEntity
        {
            PublicId = Id,
            ManufacturerId = Manufacturer.Value.Id,
            TypeId = Type.Value.Id,
            Model = Model.Value,
            Cubic = Cubic.Value ?? 0,
            ReleaseYear = ReleaseYear.Value ?? 0,
            Cylinders = CylindersNumber.Value ?? 0,
            ImageId = ImageId,
            WebContentLink = WebContentLink
        };
    }

    public void ToEntity(MotorcycleEntity entity)
    {
        entity.PublicId = Id;
        entity.ManufacturerId = Manufacturer.Value.Id;
        entity.TypeId = Type.Value.Id;
        entity.Model = Model.Value;
        entity.Cubic = Cubic.Value ?? 0;
        entity.ReleaseYear = ReleaseYear.Value ?? 0;
        entity.Cylinders = CylindersNumber.Value ?? 0;
        entity.ImageId = ImageId;
        entity.WebContentLink = WebContentLink;
    }

    private void AddValidators()
    {
        this.Manufacturer.Validations.Add(new PickerValidationRule<ManufacturerModel>()
        {
            ValidationMessage = "Manufacturer must be selected"
        });

        this.Type.Validations.Add(new PickerValidationRule<TypeModel>()
        {
            ValidationMessage = "Type must be selected"
        });

        this.Model.Validations.Add(new IsNotNullOrEmptyRule<string>
        {
            ValidationMessage = "Model field is required"
        });

        this.Cubic.Validations.AddRange(
        [
            new NullableIntegerRule<uint?>
            {
                ValidationMessage = "Cubic field is required"
            },
            new MinValueRule<uint?>(1)
            {
                ValidationMessage = "Cubic field must be greater the 0"
            }
        ]);

        this.ReleaseYear.Validations.AddRange(
        [
            new NullableIntegerRule<uint?>
            {
                ValidationMessage = "Release Year field is required"
            },
            new MaxValueRule<uint?>(DateTime.Now.Year)
            {
                ValidationMessage = "Release Year cant be greater then the current year"
            }
        ]);

        this.CylindersNumber.Validations.AddRange(new NullableIntegerRule<uint?>
        {
            ValidationMessage = "Cylinder field is required"
        });
    }
}
