namespace MasterMind.Communication
{
    public interface ICommunicationOperations
    {
        void WriteLine(string content);

        string Read();
    }
}