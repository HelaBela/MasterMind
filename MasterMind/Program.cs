using System;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            var communication = new ConsoleOperations();
           var player = new PlayerInput(communication);
           player.GetColors();
        }
    }
}