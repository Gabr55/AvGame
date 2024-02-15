using AvGame;
using System.Runtime.CompilerServices;
using static System.Console;


WriteLine("Для старта нажмите любую кнопку:");
ReadKey();

Game newGame = new();

WriteLine("Введите команду");

// Создаем экземпляр класса для прослушивания команд
CommandListener listener = new CommandListener();

// Подписываемся на событие
listener.CommandReceived += (sender, e) =>
{
    // e.Command e.Parameter
    WriteLine("");
    switch (e.Command.ToLower())
    {
        case "осмотреться":
            newGame.LookAround(newGame.Player);
            break;
        case "идти":
            newGame.Walk(newGame.Player, e.Parameter);
            break;
        case "взять":
            newGame.Take(newGame.Player, e.Parameter);
            break;
        default:
            WriteLine("Нет такой команды");
            break;
    }
};

// Запускаем прослушивание команд
listener.ListenForCommands();