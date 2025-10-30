namespace CalculatorForEveryMatrix.Services;

public class InputService
{
    public bool TryParseNumber(string input, out double number)
    {
        return double.TryParse(input, System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, out number);
    }
}