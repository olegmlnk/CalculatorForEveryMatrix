using CalculatorForEveryMatrix.Abstractions;

namespace CalculatorForEveryMatrix.Core;

public class Calculator
{
    public double Calculate(double a, double b, IOperation operation) =>
        operation.Execute(a, b);
}