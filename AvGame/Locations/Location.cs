using AvGame.Items;
using static System.Console;

namespace AvGame.Locations;


public abstract class Location
{
    public Location(string name)
    {
        Name = name;
    }
    public string Name { get; private set; }
    public virtual List<Location> NeighborList {set; get; }
    public virtual List<Item>? Items { set; get; }

}
