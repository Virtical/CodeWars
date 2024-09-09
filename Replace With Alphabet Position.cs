using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
public static class Kata
{
    public static string AlphabetPosition(string text)
    {
        return string.Join(" ", text.Where(char.IsLetter).Select(x => (byte)char.ToLower(x) - 96).ToList());
    }
}