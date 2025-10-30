using CalculatorForEveryMatrix.Core;
using CalculatorForEveryMatrix.Services;

namespace CalculatorForEveryMatrix;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Welcome to Calculator!");
        Console.WriteLine($"Available operations: {OperationFactory.GetAvailableOperations()}");
        Console.WriteLine("Enter 'exit' to quit the program.\n");
        
        var calc = new Calculator();
        var input = new InputService();

        while (true)
        {
            if (!input.ReadNumber("Enter the first number: ", out double a))
                break;

            if (!input.ReadNumber("Enter the second number: ", out double b))
                break;

            var operation = input.ReadOperation("Enter the operation: ");
            if (operation == null)
                continue;

            try
            {
                double result = calc.Calculate(a, b, operation);
                Console.WriteLine($"Result: {result}\n");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero is not allowed.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
            }
        }

        Console.WriteLine("Exiting the program...");
        Thread.Sleep(800);
        Console.WriteLine("Done!");
    }
}