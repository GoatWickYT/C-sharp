public interface IPlanes
{
    public string Model { get; set; }

    public string Type { get; set; }

    public int Speed { get; }

    public bool OutOfAmmo { get; set; }

    void Attack();
}