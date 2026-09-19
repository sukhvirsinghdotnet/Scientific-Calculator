using System.Data;

namespace ScientificCalculator;

/// <summary>
/// Calculator engine handling all mathematical operations
/// </summary>
public class CalculatorEngine
{
    private string _expression = "0";
    private double _memory = 0;
    private List<string> _history = new();

    public string Expression => _expression;
    public double Memory => _memory;
    public List<string> History => new(_history);

    public CalculatorEngine()
    {
        _expression = "0";
    }

    public void AppendValue(string value)
    {
        if (_expression == "0" && value != ".")
        {
            _expression = value;
        }
        else if (value == "." && _expression.Contains("."))
        {
            return;
        }
        else
        {
            _expression += value;
        }
    }

    public void Clear()
    {
        _expression = "0";
    }

    public void Backspace()
    {
        if (_expression.Length > 1)
        {
            _expression = _expression[..^1];
        }
        else
        {
            _expression = "0";
        }
    }

    public string Calculate()
    {
        try
        {
            var result = EvaluateExpression(_expression);
            _history.Add($"{_expression} = {result}");
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public void ApplyOperator(string op)
    {
        if (_expression.EndsWith("+") || _expression.EndsWith("-") ||
            _expression.EndsWith("*") || _expression.EndsWith("/"))
        {
            _expression = _expression[..^1] + op;
        }
        else
        {
            _expression += op;
        }
    }

    public string ApplySqrt()
    {
        try
        {
            var value = double.Parse(_expression);
            var result = Math.Sqrt(value);
            _history.Add($"√({value}) = {result}");
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public string ApplySquare()
    {
        try
        {
            var value = double.Parse(_expression);
            var result = value * value;
            _history.Add($"({value})² = {result}");
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public string ApplyReciprocal()
    {
        try
        {
            var value = double.Parse(_expression);
            if (value == 0)
                return "Cannot divide by zero";

            var result = 1 / value;
            _history.Add($"1/{value} = {result}");
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public string ApplyFactorial()
    {
        try
        {
            var value = int.Parse(_expression);
            if (value < 0)
                return "Factorial of negative number";

            var result = CalculateFactorial(value);
            _history.Add($"{value}! = {result}");
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public string ApplySin()
    {
        try
        {
            var value = double.Parse(_expression);
            var radians = ConvertDegreesToRadians(value);
            var result = Math.Sin(radians);
            _history.Add($"sin({value}°) = {result}");
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public string ApplyCos()
    {
        try
        {
            var value = double.Parse(_expression);
            var radians = ConvertDegreesToRadians(value);
            var result = Math.Cos(radians);
            _history.Add($"cos({value}°) = {result}");
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public string ApplyTan()
    {
        try
        {
            var value = double.Parse(_expression);
            var radians = ConvertDegreesToRadians(value);
            var result = Math.Tan(radians);
            _history.Add($"tan({value}°) = {result}");
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public string ApplyLn()
    {
        try
        {
            var value = double.Parse(_expression);
            if (value <= 0)
                return "Invalid logarithm input";

            var result = Math.Log(value);
            _history.Add($"ln({value}) = {result}");
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public string ApplyLog10()
    {
        try
        {
            var value = double.Parse(_expression);
            if (value <= 0)
                return "Invalid logarithm input";

            var result = Math.Log10(value);
            _history.Add($"log10({value}) = {result}");
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public string ApplyExp()
    {
        try
        {
            var value = double.Parse(_expression);
            var result = Math.Exp(value);
            _history.Add($"e^{value} = {result}");
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public void ApplyPower()
    {
        _expression += "^";
    }

    public string ToggleSign()
    {
        try
        {
            var value = double.Parse(_expression);
            var result = -value;
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public string ApplyPercentage()
    {
        try
        {
            var value = double.Parse(_expression);
            var result = value / 100;
            _expression = result.ToString();
            return result.ToString();
        }
        catch
        {
            return "Error";
        }
    }

    public void MemoryAdd()
    {
        try
        {
            _memory += double.Parse(_expression);
        }
        catch { }
    }

    public void MemorySubtract()
    {
        try
        {
            _memory -= double.Parse(_expression);
        }
        catch { }
    }

    public string MemoryRecall()
    {
        _expression = _memory.ToString();
        return _expression;
    }

    public void MemoryClear()
    {
        _memory = 0;
    }

    public string GetMemoryStatus()
    {
        return _memory == 0 ? "" : $"M: {_memory}";
    }

    public void ClearHistory()
    {
        _history.Clear();
    }

    // ============ Private Helper Methods ============

    private double EvaluateExpression(string expression)
    {
        if (expression.Contains("^"))
        {
            expression = expression.Replace("^", "**");
        }

        try
        {
            var table = new DataTable();
            var result = table.Compute(expression, null);
            return Convert.ToDouble(result);
        }
        catch
        {
            throw new InvalidOperationException("Invalid expression");
        }
    }

    private long CalculateFactorial(int n)
    {
        if (n == 0 || n == 1)
            return 1;

        long result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;

        return result;
    }

    private double ConvertDegreesToRadians(double degrees)
    {
        return degrees * (Math.PI / 180);
    }

    private double ConvertRadiansToDegrees(double radians)
    {
        return radians * (180 / Math.PI);
    }
}