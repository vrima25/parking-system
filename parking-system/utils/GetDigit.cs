using System.Text.RegularExpressions;

namespace parking_system.utils;

public class GetDigit
{
    public static int DigitOf(string text)
    {
        string digit = string.Empty;
        int fixedDigit = 0;
        var matches = Regex.Matches(text, @"\d+");
        foreach(var match in matches){
            digit += match;
        }

        fixedDigit = int.Parse(digit);
        return fixedDigit;
    }
}