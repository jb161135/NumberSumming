namespace NumberSumming.Models
{
    public interface ISumModel
    {
        long Sum { get; }
        long FormattedSum { get; }
        string ErrorMessage { get; }
        long FormatNumber(string number);
        void CalculateSum(long number);
        void HandleData(string filePath);
    }
}
