namespace Source;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if(String.IsNullOrWhiteSpace(numbers))
            return 0;

        if (numbers.Contains('-'))
            throw new ArgumentOutOfRangeException();

        return numbers.Split(',', '\n').Select(int.Parse).Sum();
    }
}
