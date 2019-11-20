namespace MasterMind
{
    public class ColorChecker
    {
        private INumberGenerator _numberGenerator;
        private ICommunicationOperations _communicationOperations;

        public ColorChecker()
        {
            _numberGenerator = new RandomNumberGenerator();
            _communicationOperations = new ConsoleOperations();
        }
    }
}