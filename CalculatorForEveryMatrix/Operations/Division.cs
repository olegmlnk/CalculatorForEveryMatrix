using CalculatorForEveryMatrix.Abstractions;

namespace CalculatorForEveryMatrix.Operations;

public class Division : IOperation
{
    public string Symbol => "/";
    
    public double Execute(double a, double b) => b == 0 
        ? throw new DivideByZeroException("Division by zero is not allowed.") 
        : a / b;
}