using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

public static class Kata
{
    public static string ExpandedForm(long num)
    {
        var str = num.ToString();
        var strBuilder = new StringBuilder();

        for (var i = 0; i < str.Length; i++) 
        {
            if (str[i] != '0')
            {
                strBuilder.Append(str[i]);
                for (var j = str.Length - 1; j > i; j--)
                {
                    strBuilder.Append('0');
                }
                strBuilder.Append(" + ");
            }
        }

        strBuilder.Remove(strBuilder.Length - 3, 3);

        return strBuilder.ToString();
    }
}