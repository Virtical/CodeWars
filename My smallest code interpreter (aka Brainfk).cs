using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
public static class Kata
{
    public static string BrainLuck(string code, string input)
    {
        var inputQueue = new Queue<char>();

        foreach (var i in input)
        {
            inputQueue.Enqueue(i);
        }

        byte[] cells = new byte[32];
        var dataPointer = 0;
        var strBuilder = new StringBuilder();

        var stackOfBrackets = new Stack<int>();
        for (var i = 0; i < code.Length; i++)
        {

            switch (code[i])
            {
                case '>':
                    dataPointer = dataPointer + 1 > cells.Length - 1 ? 0 : dataPointer + 1;
                    break;
                case '<':
                    dataPointer = dataPointer - 1 < 0 ? cells.Length - 1 : dataPointer - 1;
                    break;
                case '+':
                    cells[dataPointer]++;
                    break;
                case '-':
                    cells[dataPointer]--;
                    break;
                case '.':
                    strBuilder.Append((char)cells[dataPointer]);
                    break;
                case ',':
                    cells[dataPointer] = (byte)inputQueue.Dequeue();
                    break;
                case '[':
                    stackOfBrackets.Push(i);

                    if (cells[dataPointer] == 0)
                    {
                        var openBrackets = -1;
                        while (!(code[i] == ']' && openBrackets == 0))
                        {
                            if (code[i] == '[')
                            {
                                openBrackets++;
                            }
                            else if (code[i] == ']' && openBrackets > 0)
                            {
                                openBrackets--;
                            }
                            i++;
                        }

                        stackOfBrackets.Pop();
                    }
                    break;
                case ']':
                    if (cells[dataPointer] != 0)
                    {
                        i = stackOfBrackets.Peek();
                    }
                    else
                    {
                        stackOfBrackets.Pop();
                    }
                    break;
            }
        }

        return strBuilder.ToString();
    }
}

public class Program
{
    public static void Main()
    {
        var code = ",>+>>>>++++++++++++++++++++++++++++++++++++++++++++>++++++++++++++++++++++++++++++++<<<<<<[>[>>>>>>+>+<<<<<<<-]>>>>>>>[<<<<<<<+>>>>>>>-]<[>++++++++++[-<-[>>+>+<<<-]>>>[<<<+>>>-]+<[>[-]<[-]]>[<<[>>>+<<<-]>>[-]]<<]>>>[>>+>+<<<-]>>>[<<<+>>>-]+<[>[-]<[-]]>[<<+>>[-]]<<<<<<<]>>>>>[++++++++++++++++++++++++++++++++++++++++++++++++.[-]]++++++++++<[->-<]>++++++++++++++++++++++++++++++++++++++++++++++++.[-]<<<<<<<<<<<<[>>>+>+<<<<-]>>>>[<<<<+>>>>-]<-[>>.>.<<<[-]]<<[>>+>+<<<-]>>>[<<<+>>>-]<<[<+>-]>[<+>-]<<<-]";
        Console.WriteLine(Kata.BrainLuck(code, "\n"));
    }
}