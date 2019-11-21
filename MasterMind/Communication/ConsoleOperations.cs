using System;

namespace MasterMind.Communication
{
    public class ConsoleOperations : ICommunicationOperations

    {
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }


        public string Read()
        {
            return Console.ReadLine();
        }
    }
}