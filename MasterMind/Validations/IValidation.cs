using System.Collections.Generic;

namespace MasterMind.Validations
{
    public interface IValidation
    {
        bool IsValid(List<string> userInput);
        string DisplayErrorMessage();
    }
}