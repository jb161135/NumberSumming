namespace NumberSumming.Models
{
    public interface ISumModel
    {
        long Sum { get; }
        long FormattedSum { get; }
        string ErrorMessage { get; }
        void CalculateSum(long number);
        long FormatNumber(string number);
        string MakeNumeric(string number);
        void HandleData(string filePath);
    }
}
