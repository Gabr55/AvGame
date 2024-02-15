

namespace AvGame.Locations
{
    public class Warp : Location
    {
        public Warp(string name, Area area, Area nextArea) : base(name)
        {
            Area = area;
            NextArea = nextArea;
        }

        public Area Area { get; private set; }
        public Area NextArea { get; private set; }

    }
}
