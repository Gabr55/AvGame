using AvGame.Items;
using AvGame.Locations;
using System.ComponentModel.Design;
using static System.Console;

namespace AvGame
{
    public class Game
    {
        public Game()
        {
            Player = new Player();

            // Инициализация зон
            Area houseArea = new("Дом");
            HouseArea = houseArea;
            
            Area streetArea = new("Улица");
            StreetArea = streetArea;

            // Инициализация мест
            Place hallwayPlace = new Place("Коридор", houseArea);
            HallwayPlace = hallwayPlace;
            Place roomPlace = new Place("Комната", houseArea);
            RoomPlace = roomPlace;
            Place kitchenPlace = new Place("Кухня", houseArea);
            KitchenPlace = kitchenPlace;
            Place streetPlace = new Place("Улица", streetArea);
            StreetPlace = streetPlace;

            // Инициализация переходов
            Warp streetWarp = new Warp("Улица", houseArea, streetArea);
            StreetWarp = streetWarp;
            Warp houseWarp = new Warp("Дом", streetArea, houseArea);
            HouseWarp = houseWarp;


            // Добавление соседий
            HallwayPlace.NeighborList = new List<Location> { roomPlace, kitchenPlace, streetWarp };
            RoomPlace.NeighborList = new List<Location> { hallwayPlace };
            KitchenPlace.NeighborList = new List<Location> { hallwayPlace };
            StreetPlace.NeighborList = new List<Location> { houseWarp };

            // Места по умолчанию для локаций
            HouseArea.DefaultLocation = hallwayPlace;
            StreetArea.DefaultLocation = streetPlace;

            // Стартовая позиция
            Location startPoint = roomPlace;
            Player.PlayerLocation = startPoint;

            // Инициализация предметов
            Backpack = new("Рюкзак");
            Notes = new("Конспекты");
            Keys = new("Ключи");

            // Добавление предметов на локации
            RoomPlace.Items = new List<Item> { Backpack, Notes, Keys };
        }

        public Player Player { get; private set; }

        // Свойства зон
        public Area HouseArea { get; set; }
        public Area StreetArea { get; set; }

        // Свойства мест
        public Place HallwayPlace { get; set; }
        public Place RoomPlace { get; set; }
        public Place KitchenPlace { get; set; }
        public Place StreetPlace { get; set; } 

        // Свойства переходов
        public Warp StreetWarp { get; set; }
        public Warp HouseWarp { get; set; }


        // Инициализация предметов
        public Item Backpack { get; set; }
        public Item Notes { get; set; }
        public Item Keys { get; set; }




        // Хендлеры

        public delegate void ActionHandler(string command, Player player);

        public event ActionHandler OnCommand;

        // Команда осмотреться
        public void LookAround(Player player)
        {
            WriteLine($"Ты находишься в {player.PlayerLocation.Name}");
            WriteLine($"Вокруг тебя:");
            foreach (Location location in player.PlayerLocation.NeighborList)
            {
                WriteLine(location.Name);
            }
            WriteLine("");
            WriteLine("Предметы рядом:");
            if (player.PlayerLocation.Items is not null)
            {
                foreach (Item i in player.PlayerLocation.Items)
                {
                    WriteLine(i.Name);
                }
            }
            else
            {
                WriteLine("Рядом нет предметов");
            }
            WriteLine("");
        }

        // Команда идти
        public void Walk(Player player, string? locationName)
        {
            try
            {
                if (locationName is not null)
                {
                    Location? location = player.PlayerLocation.NeighborList.
                        FirstOrDefault(l => l.Name.ToLower() == locationName.ToLower());
                    if (location is not null &&
                        location.GetType() == typeof(Place))
                    {
                        WriteLine($"Передвигаемся из: {player.PlayerLocation.Name}");
                        player.PlayerLocation = location;
                        WriteLine($"Передвигаемся в: {player.PlayerLocation.Name}");
                    }
                    else
                    {
                        WriteLine("Такого пути нет");
                    }
                }
                else
                {
                    WriteLine("Параметр пути не задан");
                }
            }
            catch (Exception e)
            {
                WriteLine("Ошибка в имени пути");
            }
            WriteLine("");
        }

        // Команда взять
        public void Take(Player player, string? itemName)
        {
            try
            {
                if (itemName is not null)
                {
                    Item? item = player.PlayerLocation.Items.
                        FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
                    if (item is not null)
                    {
                        WriteLine("");
                        WriteLine($"Поднимаем {item.Name}");
                        player.Items.Add(item);
                        player.PlayerLocation.Items.Remove(item);
                        WriteLine("");
                        WriteLine("Предметы в инвентаре:");
                        foreach (Item i in player.Items)
                        {
                            WriteLine(i.Name);
                        }
                    }
                    else
                    {
                        WriteLine("");
                        WriteLine("Такого предмета нет");
                    }
                }
                else
                {
                    WriteLine("Параметр предмета не задан");
                }
                
            }
            catch (Exception e)
            {
                WriteLine("Ошибка в имени предмета");
            }
            WriteLine("");
        }
    }
}
