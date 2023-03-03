namespace Source;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if(String.IsNullOrWhiteSpace(numbers))
            return 0;

        if (numbers.Contains('-'))
            throw new ArgumentOutOfRangeException();

        return numbers.Split(',', '\n').Select(Parse).Sum();
    }

    private int Parse(string number)
    {
        var result = int.Parse(number);
        return result > 1000 ? 0 : result;
    }
}
