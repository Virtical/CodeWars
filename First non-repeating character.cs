using System.Linq;
using System.Collections.Generic

public class Kata
{
    public static string FirstNonRepeatingLetter(string s)
    {
        var notRepeatedLetter = new LinkedList<char>();
        var repeatedLetter = new HashSet<char>();

        foreach (char l in s)
        {
            if (!repeatedLetter.Contains(char.ToLower(l)) && !notRepeatedLetter.Contains(char.ToUpper(l)) && !notRepeatedLetter.Contains(char.ToLower(l)))
            {
                notRepeatedLetter.AddLast(l);
            }
            else if (notRepeatedLetter.Contains(char.ToUpper(l)) || notRepeatedLetter.Contains(char.ToLower(l)))
            {
                notRepeatedLetter.Remove(char.ToUpper(l));
                notRepeatedLetter.Remove(char.ToLower(l));
                repeatedLetter.Add(char.ToLower(l));
            }
        }

        if (notRepeatedLetter.Count > 0)
        {
            return notRepeatedLetter.First().ToString();
        }
        else
        {
            return string.Empty;
        }
    }
}