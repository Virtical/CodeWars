using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static int GetUnique(IEnumerable<int> numbers)
    {
        var firstList = new List<int>();
        var secondList = new List<int>();

        foreach (var number in numbers)
        {
            if (firstList.Count == 0)
            {
                firstList.Add(number);
            }
            else if (number == firstList.First())
            {
                firstList.Add(number);
            }
            else
            {
                secondList.Add(number);
            }
        }

        return firstList.Count > 1 ? secondList.First() : firstList.First();
    }
}