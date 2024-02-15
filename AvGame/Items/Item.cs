using AvGame.Locations;
using static System.Console;


namespace AvGame.Items;

public class Item
{
    public Item(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
}
