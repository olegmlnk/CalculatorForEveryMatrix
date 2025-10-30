namespace CalculatorForEveryMatrix.Abstractions;

public interface IOperation
{
    string Symbol { get; }
    double Execute(double a, double b);
}