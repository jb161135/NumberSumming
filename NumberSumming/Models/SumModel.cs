using System;
using System.IO;
using System.Linq;
using System.Numerics;

namespace NumberSumming.Models
{
    /// <summary>
    /// Class <c>SumModel</c> handles the logic behind getting data and performing
    /// summing operations on the data.
    /// </summary>
    public class SumModel : ISumModel
    {
        const int MAX_DIGITS = 10;
        private string number = string.Empty;
        private long formattedNumber;
        public long Sum { get; private set; }
        public long FormattedSum { get; private set; }
        public string ErrorMessage { get; private set; } = string.Empty;

        /// <summary>
        /// Method <c>CalculateSum</c> adds <paramref name="number"/> to the current sum.
        /// </summary>
        /// <param name="number">the number to be added.</param>
        public void CalculateSum(long number)
        {
            Sum += number;
            FormattedSum = FormatNumber(Sum.ToString());
        }

        /// <summary>
        /// Method <c>FormatNumber</c> formats <paramref name="number"/> to only 
        /// include the final 10 digits and a negative symbol if present in the original number.
        /// </summary>
        /// <param name="number">the string to be formatted.</param>
        /// <returns>
        /// A long representation of the formatted number.
        /// </returns>
        public long FormatNumber(string number)
        {
            number = MakeNumeric(number);

            // if not a number throw exception
            try
            {
                long formattedNumber;
                string numberSubstring = string.Empty;

                // check for negative numbers
                if (number.Length > 0 && number[0] == '-')
                {
                    numberSubstring = "-";
                }

                // anything beyond the last 10 digits is unnecessary information, so get rid of it
                if (number.Length > 0 && number.Length > MAX_DIGITS)
                {
                    numberSubstring += number.Substring(number.Length - MAX_DIGITS);

                    formattedNumber = long.Parse(numberSubstring);
                }
                else
                {
                    formattedNumber = long.Parse(number);
                }

                return formattedNumber;
            }
            catch(Exception e)
            {
                ErrorMessage = "Nonnumeric value found, replaced with zero.";
            }

            // if not a number return zero to be added to sum
            return 0;
        }

        /// <summary>
        /// Method <c>MakeNumeric</c> removes all characters from <paramref name="number"/> that are 
        /// nonnumeric, while leaving any negative symbols.
        /// </summary>
        /// <param name="number">the number to be made numeric.</param>
        /// <returns>
        /// The string with the nonnumeric characters removed.
        /// </returns>
        public string MakeNumeric(string number)
        {
            return new string(number.Where(p => char.IsDigit(p) || p == '-').ToArray());
        }

        /// <summary>
        /// Method <c>HandleData</c> opens <paramref name="filePath"/> to read in all 
        /// numbers from the file.
        /// </summary>
        /// <param name="filePath">the path to the csv file to read data from.</param>
        public void HandleData(string filePath)
        {
            try
            {
                // reset sum and error message each time a file is selected
                Sum = 0;
                ErrorMessage = string.Empty;

                StreamReader sr = new StreamReader(filePath);
                number = sr.ReadLine();
                formattedNumber = FormatNumber(number);
                CalculateSum(formattedNumber);

                while (!sr.EndOfStream)
                {
                    number = sr.ReadLine();
                    formattedNumber = FormatNumber(number);
                    CalculateSum(formattedNumber);
                }
                sr.Close();
            }
            catch (Exception e)
            {
                ErrorMessage = "Unable to read from file.";
            }
        }
    }
}
