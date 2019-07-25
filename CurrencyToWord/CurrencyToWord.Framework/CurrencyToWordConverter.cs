using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyToWord.Framework
{
    public class CurrencyToWordConverter
    {
        public string ConvertAmount(string amountWithCurrency)
        {
            StringBuilder result = new StringBuilder();

            (string currency, string amount) = SeparateAmountAndCurrency(amountWithCurrency);
            (string wholePart, string cents) = SeparateWholePartAndCents(amount);

            if (!string.IsNullOrEmpty(wholePart))
            {
                var words = new List<string>();

                for (int i = wholePart.Length - 1, n = 1; i >= 0; i--, n *= 10)
                {
                    string mapKey = string.Empty;

                    if (n == 10)
                    {
                        if (wholePart[i] == '1')
                        {
                            words.RemoveAt(0);
                            mapKey = $"{wholePart[i]}{wholePart[i + 1]}";
                        }
                        else
                        {
                            mapKey = (char.GetNumericValue(wholePart[i]) * n).ToString();
                        }
                    }
                    else
                    {
                        mapKey = (char.GetNumericValue(wholePart[i])).ToString();
                    }


                    if (n == 100)
                    {
                        words.Insert(0, "and");
                        words.Insert(0, "hundred");
                    }
                    if (n == 1000)
                    {
                        words.Insert(0, "thousand");
                    }

                    words.Insert(0, DigitMapper.Map[mapKey]);
                }

                result.AppendJoin(' ', words.Where(word => !string.IsNullOrEmpty(word)));

                result.Append($" {currency}");
            }

            if (!string.IsNullOrEmpty(cents) && cents != "00")
            {
                result.Append(" and ");

                if (DigitMapper.TeensMap.ContainsKey(cents))
                {
                    result.Append(DigitMapper.TeensMap[cents]);
                }
                else
                {
                    var words = new List<string>();

                    for (int i = cents.Length - 1, n = 1; i >= 0; i--, n *= 10)
                    {
                        var mapKey = (char.GetNumericValue(cents[i]) * n).ToString();
                        words.Insert(0, DigitMapper.Map[mapKey]);
                    }

                    result.AppendJoin(' ', words.Where(word => !string.IsNullOrEmpty(word)));
                }
                
                result.Append(" cents");
            }

            string compiledResult = result.ToString();

            compiledResult = $"{char.ToUpper(compiledResult[0])}{compiledResult.Substring(1)}";

            return compiledResult;
        }

        private (string wholePart, string cents) SeparateWholePartAndCents(string amount)
        {
            var parts = amount.Split('.');

            if (parts.Length == 1)
            {
                return (parts[0], null);
            }

            return (parts[0], parts[1]);
        }

        private (string currency, string amount) SeparateAmountAndCurrency(string amountWithCurrency)
        {
            return (CurrencyMapper.Map["R"], amountWithCurrency.Replace("R", ""));
        }
    }
}
