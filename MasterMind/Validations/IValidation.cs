using System.Collections.Generic;

namespace MasterMind
{
    public interface IValidation
    {
        bool IsValid(List<string> userInput);
        string DisplayErrorMessage();
    }
}