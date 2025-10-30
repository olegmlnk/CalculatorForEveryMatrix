using CalculatorForEveryMatrix.Abstractions;
using CalculatorForEveryMatrix.Operations;

namespace CalculatorForEveryMatrix.Core;

public class OperationFactory
{
    private static readonly List<IOperation> _operations = new()
    {
        new Addition(),
        new Subtraction(),
        new Multiplication(),
        new Division()
    };

    public static IOperation? GetOperation(string symbol) =>
        _operations.FirstOrDefault(o => o.Symbol == symbol);

    public static string GetAvailableOperations() =>
    string.Join(" ", _operations.Select(o => o.Symbol));
    
}