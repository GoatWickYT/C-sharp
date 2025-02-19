namespace Solution.Core.Models;

public class TypeModel : IObjectValidator<uint>
{
    public uint Id { get; set; }

    public string Name { get; set; }

    public TypeModel()
    {
    }

    public TypeModel(uint id, string name)
    {
        Id = id;
        Name = name;
    }

    public TypeModel(ManufacturerEntity entity)
    {
        if (entity is null)
        {
            return;
        }
        Id = entity.Id;
        Name = entity.Name;
    }

    public override bool Equals(object? obj)
    {
        return obj is TypeModel type &&
               this.Id == type.Id &&
               this.Name == type.Name;
    }
}
