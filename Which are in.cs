using System.Collections.Generic;
using System.Linq;

class WhichAreIn
{
    public static string[] inArray(string[] array1, string[] array2)
    {
        var d = new HashSet<string>();
        var r = array1.Where(x => array2.Where(y => y.Contains(x)).Count() > 0).ToList();
        r.Sort();
        return r.ToArray();
    }
}