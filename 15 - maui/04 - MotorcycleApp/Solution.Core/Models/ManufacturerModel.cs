namespace Solution.Core.Models;

public class ManufacturerModel
{
    public uint Id { get; set; }
    public string Name { get; set; }

    public ManufacturerModel()
    {
        Name = "";
    }


    public ManufacturerModel(ManufacturerEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
    }

    public ManufacturerEntity ToEntity()
    {
        return new ManufacturerEntity
        {
            Id = Id,
            Name = Name
        };
    }

    public void ToEntity(ManufacturerEntity entity)
    {
        entity.Id = Id;
        entity.Name = Name;
    }
}
