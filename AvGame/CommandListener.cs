using System;
using System.Threading;
using static System.Console;

namespace AvGame
{
    public delegate void CommandReceivedEventHandler(object sender, CommandReceivedEventArgs e);
    public class CommandReceivedEventArgs : EventArgs
    {
        public string Command { get; private set; }
        public string Parameter { get; private set; }

        public CommandReceivedEventArgs(string command, string parameter)
        {
            Command = command;
            Parameter = parameter;
        }
    }

    public class CommandListener
    {
        // Событие, которое будет вызываться при получении команды
        public event CommandReceivedEventHandler CommandReceived;

        // Метод для начала прослушивания ввода с консоли
        public void ListenForCommands()
        {
            while (true)
            {
                // Чтение строки из консоли
                string input = ReadLine();

                // Разбор строки на команду и параметр
                string[] parts = input.Split(' ');
                string command = parts[0];
                string parameter = parts.Length > 1 ? parts[1] : null;

                // Проверка команды и вызов события
                switch (command.ToLower())
                {
                    case "осмотреться":
                        OnCommandReceived(new CommandReceivedEventArgs(command, parameter));
                        break;
                    case "идти":
                        OnCommandReceived(new CommandReceivedEventArgs(command, parameter));
                        break;
                    case "взять":
                        OnCommandReceived(new CommandReceivedEventArgs(command, parameter));
                        break;
                    default:
                        WriteLine("Нет такой команды");
                        break;
                }
            }
        }

        // Метод для вызова события
        protected virtual void OnCommandReceived(CommandReceivedEventArgs e)
        {
            CommandReceived?.Invoke(this, e);
        }
    }
}
