using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();
            bool isBalanced = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '[' || input[i] == '(')
                {
                    stack.Push(input[i]);
                }
                else if (input[i] == '}')
                {
                    if (stack.Count != 0)
                    {
                        if (stack.Peek() != '{')
                        {
                            Console.WriteLine("NO");
                            isBalanced = false;
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        isBalanced = false;
                        break;
                    }

                }
                else if (input[i] == ']')
                {
                    if (stack.Count != 0)
                    {
                        if (stack.Peek() != '[')
                        {
                            Console.WriteLine("NO");
                            isBalanced = false;
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        isBalanced = false;
                        break;
                    }

                }
                else if (input[i] == ')')
                {
                    if (stack.Count != 0)
                    {
                        if (stack.Peek() != '(')
                        {
                            Console.WriteLine("NO");
                            isBalanced = false;
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        isBalanced = false;
                        break;
                    }
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
        }
    }
}
