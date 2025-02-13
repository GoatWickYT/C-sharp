namespace Solution.Core.Models;

public class ManufacturerModel : IObjectValidator<uint>
{
    public uint Id { get; set; }

    public string Name { get; set; }

    public ManufacturerModel()
    {
    }

    public ManufacturerModel(uint id, string name)
    {
        Id = id;
        Name = name;
    }

    public ManufacturerModel(ManufacturerEntity entity)
    {
        if(entity is null)
        {
            return;
        }

        Id = entity.Id;
        Name = entity.Name;
    }

    public override bool Equals(object? obj)
    {
        return obj is ManufacturerModel model &&
               this.Id == model.Id &&
               this.Name == model.Name;
    }
}
