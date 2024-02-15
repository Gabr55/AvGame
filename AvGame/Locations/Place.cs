
using AvGame.Items;

namespace AvGame.Locations
{
    public class Place : Location
    {
        public Place (string name, Area area) : base(name)
        {
            Area = area;
        }

        public Area Area { get; private set; }

        public override List<Location> NeighborList { get; set; }

        public override List<Item>? Items { get; set; }
    }
}
