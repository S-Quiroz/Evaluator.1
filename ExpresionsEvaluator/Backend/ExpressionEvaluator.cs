using System.Data;
using System.Runtime.CompilerServices;

namespace Backend;

public static class ExpressionEvaluator
{
    private static string posFix;

    public static double Evalute(string infix)
    {
        var postfix = ToPostfix(infix);
        
        return EvalutePostfix(postfix);
    }

    private static string ToPostfix(string infix)

    {

        var posfix = string.Empty;
        var stack = new Stack<char>();
        foreach (var item in posfix)
        {
            if (IsOperator(item))
            {
                if (item == ')')
                {

                    var ope = stack.Pop();
                    while (ope != '(')
                    {
                        posfix += ope;
                        ope = stack.Pop();
                    }
                }
                else
                    if (stack.Count == 0)
                    {
                        stack.Push(item);
                    }
                    else
                    {
                        if (PriorityInfix(item) > PriorityStack(stack.Peek()))
                        {
                            stack.Push(item); // enter 
                        }
                        else
                        {
                            posfix += stack.Pop(); // exit and enter 
                        }
                    }
            }

            else
            {
                posfix += item;
            }
            do
            {
                posfix += stack.Pop();
                while (stack.Count != 0) ;
            } while (stack.Count != 0);
            return posfix;
        }
    }

    private static int PriorityStack(Char op) => op switch
    {
            '^' => 3,
            '*' => 2,
            '/' => 2,
            '+' => 1,
            '-' => 1,
            '(' => 0,
            _ => throw new Exception("Invalid expression")
    };
    private static int PriorityInfix(char op) => op switch
    {
            '^' => 4,
            '*' => 2,
            '/' => 2,
            '+' => 1,
            '-' => 1,
            '(' => 5,
        _ => throw new Exception("Invalid expression")
    };
   
    private static bool IsOperator(char item) => item == '^' || item == '*' || item == '/' || item == '+' || item == '-' || item == '(' || item == ')';
    private static double EvalutePostfix(string postfix)
    {
        throw new NotImplementedException();
    }


}
