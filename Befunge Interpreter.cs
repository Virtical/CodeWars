using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System;

public class BefungeInterpreter
{
    class indicator
    {
        public int Row = 0;
        public int Column = 0;

        public void MoveRight() => Column++;
        public void MoveLeft() => Column--;
        public void MoveDown() => Row++;
        public void MoveUp() => Row--;
    }
    public string Interpret(string code)
    {
        var tableCode = code.Split('\n');
        var i = new indicator();
        var move = new Action<indicator>((i) => i.MoveRight() );
        var strBuilder = new StringBuilder();

        var stack = new Stack<int>();

        while (tableCode[i.Row][i.Column] != '@')
        {
            switch (tableCode[i.Row][i.Column])
            {
                case '0': case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9':
                    stack.Push(tableCode[i.Row][i.Column] - '0');
                    break;
                case '+':
                    stack.Push(stack.Pop() + stack.Pop());
                    break;
                case '-':
                    var a0 = stack.Pop();
                    var b0 = stack.Pop();
                    stack.Push(b0 - a0);
                    break;
                case '*':
                    stack.Push(stack.Pop() * stack.Pop());
                    break;
                case '/':
                    var a1 = stack.Pop();
                    var b1 = stack.Pop();
                    if (a1 == 0)
                    {
                        stack.Push(0);
                    }
                    else
                    {
                        stack.Push(b1 / a1);
                    }
                    break;
                case '%':
                    var a2 = stack.Pop();
                    var b2 = stack.Pop();
                    if (a2 == 0)
                    {
                        stack.Push(0);
                    }
                    else
                    {
                        stack.Push(b2 / a2);
                    }
                    break;
                case '!':
                    var a3 = stack.Pop();
                    if (a3 == 0)
                    {
                        stack.Push(1);
                    }
                    else
                    {
                        stack.Push(0);
                    }
                    break;
                case '`':
                    stack.Push(stack.Pop() < stack.Pop() ? 1 : 0);
                    break;
                case '>':
                    move = (i) => i.MoveRight();
                    break;
                case '<':
                    move = (i) => i.MoveLeft();
                    break;
                case '^':
                    move = (i) => i.MoveUp();
                    break;
                case 'v':
                    move = (i) => i.MoveDown();
                    break;
                case '?':
                    var random = new Random();
                    switch (random.Next(0, 5))
                    {
                        case 0:
                            move = (i) => i.MoveRight();
                            break;
                        case 1:
                            move = (i) => i.MoveLeft();
                            break;
                        case 2:
                            move = (i) => i.MoveUp();
                            break;
                        case 3:
                            move = (i) => i.MoveDown();
                            break;
                    }
                    break;
                case '_':
                    move = stack.Pop() == 0 ? (i) => i.MoveRight() : (i) => i.MoveLeft();
                    break;
                case '|':
                    move = stack.Pop() == 0 ? (i) => i.MoveDown() : (i) => i.MoveUp();
                    break;
                case '"':
                    do
                    {
                        move(i);
                        if (tableCode[i.Row][i.Column] != '"')
                        {
                            stack.Push((byte)tableCode[i.Row][i.Column]);
                        }
                    }
                    while (tableCode[i.Row][i.Column] != '"');
                    break;
                case ':':
                    stack.Push(stack.Count() == 0 ? 0 : stack.Peek());
                    break;
                case '\\':
                    var a4 = stack.Pop();
                    var b4 = stack.Count() > 0 ? stack.Pop() : 0;

                    stack.Push(a4);
                    stack.Push(b4);
                    break;
                case '$':
                    stack.Pop();
                    break;
                case '.':
                    strBuilder.Append(stack.Pop());
                    break;
                case ',':
                    strBuilder.Append((char)stack.Pop());
                    break;
                case '#':
                    move(i);
                    break;
                case 'p':
                    var a5 = stack.Pop();
                    var b5 = stack.Pop();
                    var c5 = stack.Pop();
                    StringBuilder sb = new StringBuilder(tableCode[a5]);
                    sb[b5] = (char)c5;
                    tableCode[a5] = sb.ToString();
                    break;
                case 'g':
                    var a6 = stack.Pop();
                    var b6 = stack.Pop();
                    var r = tableCode[a6][b6];
                    stack.Push((byte)r);
                    break;
            }

            move(i);
        }
        return strBuilder.ToString();
    }
}
