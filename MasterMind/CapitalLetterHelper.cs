namespace MasterMind
{
    public static class HelperCapitalLetter
    {
        public static string GetCapitalized(this string word)
        {
            return word[0].ToString().ToUpper() + word.Substring(1);
        }
    }
}