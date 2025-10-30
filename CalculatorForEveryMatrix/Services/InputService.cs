using CalculatorForEveryMatrix.Abstractions;
using CalculatorForEveryMatrix.Core;

namespace CalculatorForEveryMatrix.Services;

public class InputService
{
    public bool TryParseNumber(string input, out double number)
    {
        return double.TryParse(input, System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, out number);
    }
    
    public bool ReadNumber(string prompt, out double number)
    {
        number = 0;

        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
                return false;

            if (TryParseNumber(input, out number))
                return true;

            Console.WriteLine($"Value '{input}' is not a valid number.\n");
        }
    }

    public IOperation? ReadOperation(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string symbol = Console.ReadLine();

            if (symbol.ToLower() == "exit")
                return null;

            var operation = OperationFactory.GetOperation(symbol);

            if (operation != null)
                return operation;

            Console.WriteLine($"Operation '{symbol}' is not supported.\n");
        }
    }
}