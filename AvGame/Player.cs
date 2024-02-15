using AvGame.Items;
using AvGame.Locations;
using static System.Console;

namespace AvGame;

public class Player
{
    public string Name { get; set; } = "Игрок";

    public List<Item> Items { get; set; } = new List<Item>();

    public Location PlayerLocation { get; set; }

}
