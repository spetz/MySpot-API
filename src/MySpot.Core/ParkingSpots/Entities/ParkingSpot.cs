namespace MySpot.Core.ParkingSpots.Entities;

public class ParkingSpot
{
    public Guid Id { get;  private set; }
    public string Name { get; private set; }
    public int DisplayOrder { get; private set; }

    private ParkingSpot()
    {
    }

    public ParkingSpot(Guid id, string name, int displayOrder)
    {
        Id = id;
        Name = name;
        DisplayOrder = displayOrder;
    }
}