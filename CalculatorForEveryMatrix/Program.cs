using System.Globalization;
using CalculatorForEveryMatrix.Core;
using CalculatorForEveryMatrix.Services;

namespace CalculatorForEveryMatrix;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Welcome to Calculator!");
        Console.WriteLine($"Available operations: {OperationFactory.GetAvailableOperations()}");
        Console.WriteLine("Enter 'exit' to quit the program.");
        
        var calc = new Calculator();
        var input = new InputService();

        while (true)
        {
            Console.WriteLine("Enter the first: ");
            Console.WriteLine();
            string firstInputValue = Console.ReadLine();

            if (firstInputValue.ToLower() == "exit")
                break;
            
            if(!input.TryParseNumber(firstInputValue, out double a))
            {
                Console.WriteLine($"Value {firstInputValue} is not a valid number.");
                continue;
            }
            
            Console.Write("Enter the second number: ");
            string secondInputValue = Console.ReadLine();
            if (firstInputValue.ToLower() == "exit")
                break;
            
            if (!input.TryParseNumber(secondInputValue, out double b))
            {
                Console.WriteLine($"Value {secondInputValue} is not a valid number.");
                continue;
            }

            Console.WriteLine("Enter the operation: ");
            string operationSymbol = Console.ReadLine();
            
            var operation = OperationFactory.GetOperation(operationSymbol);

            if (operation == null)
            {
                Console.WriteLine($"Operation '{operationSymbol}' is not supported.");
                continue;
            }

            try
            {
                double result = calc.Calculate(a, b, operation);
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        Console.WriteLine("Exiting the program...");
        Task.Delay(800);
        Console.WriteLine("Done!");
    }
}