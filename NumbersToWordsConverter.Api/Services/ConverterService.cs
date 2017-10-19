using NumbersToWordsConverter.Api.Interfaces;
using NumbersToWordsConverter.Api.Models;
using System;
using System.Threading.Tasks;

namespace NumbersToWordsConverter.Api.Services
{
    public class ConverterService : IConverterService
    {
        private NumbersToWordsModel numbersToWordsModel;
        private DataModel result;

        public ConverterService()
        {
            numbersToWordsModel = new NumbersToWordsModel();
            result = new DataModel();
        }

        public DataModel ProcessConversion(DataModel dataModel)
        {
            result.Name = dataModel.Name;
            result.Numbers = dataModel.Numbers;

            //with decimal points
            if (dataModel.Numbers % 1 > 0)
            {
                string[] number = dataModel.Numbers.ToString().Split('.');

                string wholeNumberValue = string.Format("{0} DOLLARS", ConvertNumberToWords(Convert.ToInt32(number[0])).Words);
                result.Words = string.Empty;
                string decimalValue = string.Format(" AND {0} CENTS", ConvertNumberToWords(Convert.ToInt32(number[1])).Words);

                result.Words = wholeNumberValue + decimalValue;
            }
            //whole number only
            else
            {
                result = ConvertNumberToWords(Convert.ToInt32(dataModel.Numbers));
                result.Words = string.Format("{0} DOLLARS", result.Words);
            }

            return result;
        }

        private DataModel ConvertNumberToWords(int value)
        {
            //Ones
            if (value <= 9)
            {
                result.Words += numbersToWordsModel.Ones[value].Item2;
            }
            //Teens
            else if (value <= 19)
            {
                result.Words += numbersToWordsModel.Teens[value % 10].Item2;
            }
            //Tens
            else if (value <= 99)
            {
                int tens = (int)(Math.Floor((double)value / 10.0));
                int ones = value % 10;
                result.Words += numbersToWordsModel.Tens[tens].Item2 + "-";
                ConvertNumberToWords(ones);
            }
            //Hundreds
            else if (value <= 999)
            {
                int hundreds = (int)(Math.Floor((double)value / 100.0));
                int tens = (int)(Math.Floor((double)value % 100.0));

                result.Words += numbersToWordsModel.Ones[hundreds].Item2 + " " + numbersToWordsModel.Hundreds[0].Item2 + " ";
                ConvertNumberToWords(tens);
            }
            //Thousands
            else if (value <= 9999)
            {
                int thousands = (int)(Math.Floor((double)value / 1000.0));
                int hundreds = (int)(Math.Floor((double)value % 1000.0));

                result.Words += numbersToWordsModel.Ones[thousands].Item2 + " " + numbersToWordsModel.Hundreds[1].Item2 + " ";
                ConvertNumberToWords(hundreds);
            }
            //Ten Thousands
            else if (value <= 99999)
            {
                int tenthousands = (int)(Math.Floor((double)value / 10000.0));
                int thousands = (int)(Math.Floor((double)value % 10000.0));

                result.Words += numbersToWordsModel.Tens[tenthousands].Item2 + "-"; //+ numbersToWordsModel.Hundreds[1].Item2 + " "; ;
                ConvertNumberToWords(thousands);
            }
            //Hundred Thousands
            else if (value <= 999999)
            {
                int hundredthousands = (int)(Math.Floor((double)value / 100000.0));
                int tenthousands = (int)(Math.Floor((double)value % 100000.0));

                result.Words += numbersToWordsModel.Ones[hundredthousands].Item2 + " " + numbersToWordsModel.Hundreds[0].Item2 + " ";
                ConvertNumberToWords(tenthousands);
            }
            //Million
            else if (value <= 9999999)
            {
                int million = (int)(Math.Floor((double)value / 1000000.0));
                int hundredthousands = (int)(Math.Floor((double)value % 1000000.0));

                result.Words += numbersToWordsModel.Ones[million].Item2 + " " + numbersToWordsModel.Hundreds[2].Item2 + " ";
                ConvertNumberToWords(hundredthousands);
            }

            FormatWords();

            return result;
        }

        private void FormatWords()
        {
            result.Words = result.Words.TrimEnd().ToUpper();

            if (result.Words.Contains("TEN-ONE"))
            {
                result.Words = result.Words.Replace("TEN-ONE", numbersToWordsModel.Teens[1].Item2);
            }
            else if (result.Words.Contains("TEN-TWO"))
            {
                result.Words = result.Words.Replace("TEN-TWO", numbersToWordsModel.Teens[2].Item2);
            }
            else if (result.Words.Contains("TEN-THREE"))
            {
                result.Words = result.Words.Replace("TEN-THREE", numbersToWordsModel.Teens[3].Item2);
            }
            else if (result.Words.Contains("TEN-FOUR"))
            {
                result.Words = result.Words.Replace("TEN-FOUR", numbersToWordsModel.Teens[4].Item2);
            }
            else if (result.Words.Contains("TEN-FIVE"))
            {
                result.Words = result.Words.Replace("TEN-FIVE", numbersToWordsModel.Teens[5].Item2);
            }
            else if (result.Words.Contains("TEN-SIX"))
            {
                result.Words = result.Words.Replace("TEN-SIX", numbersToWordsModel.Teens[6].Item2);
            }
            else if (result.Words.Contains("TEN-SEVEN"))
            {
                result.Words = result.Words.Replace("TEN-SEVEN", numbersToWordsModel.Teens[7].Item2);
            }
            else if (result.Words.Contains("TEN-EIGHT"))
            {
                result.Words = result.Words.Replace("TEN-EIGHT", numbersToWordsModel.Teens[8].Item2);
            }
            else if (result.Words.Contains("TEN-NINE"))
            {
                result.Words = result.Words.Replace("TEN-NINE", numbersToWordsModel.Teens[9].Item2);
            }
        }
    }
}