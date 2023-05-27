using System.Text.RegularExpressions;
public class RegexHelper
{
    public string prompt,  pattern,  errorMessage;

    public RegexHelper()
    {
        prompt = "";
        pattern = "";
        errorMessage = "";


    }
   public string ReadInput(string prompt, string pattern, string errorMessage)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (Regex.IsMatch(input, pattern))
            {
                return input;
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
        }
    }
}