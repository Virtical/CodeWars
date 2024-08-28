using System;
using System.Linq;
using System.Collections.Generic;

public class Brace
{
    public static bool validBraces(String braces)
    {
        var bracesStack = new Stack<char>();

        foreach (var brace in braces)
        {
            if (brace == '(' || brace == '[' || brace == '{')
            {
                bracesStack.Push(brace);
            }
            else
            {
                if (bracesStack.Count != 0 && ((brace == ')' && bracesStack.Peek() == '(') || (brace == ']' && bracesStack.Peek() == '[') || (brace == '}' && bracesStack.Peek() == '{')))
                {
                    bracesStack.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        if (bracesStack.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}