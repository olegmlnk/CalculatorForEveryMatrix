using System.Numerics;

namespace CalculatorForEveryMatrix.Models;
public enum Operation
{
    Add,
    Subtract,
    Multiply,
    Divide
}
public class OperationExtension
{

    public static bool TryParse(string input, out Operation operation)
    {
        switch(input)
        {
            case "+":
                operation = Operation.Add;
                return true;
            case "-":
                operation = Operation.Subtract;
                return true;
            case "*":
                operation = Operation.Multiply;
                return true;
            case "/":
                operation = Operation.Divide;
                return true;
            default:
                operation = default;
                return false;
        };
    }
}