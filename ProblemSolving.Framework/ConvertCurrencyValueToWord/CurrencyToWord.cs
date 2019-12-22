using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProblemSolving.Framework.ConvertCurrencyValueToWord
{
    public class CurrencyToWord
    {
        public class Solution
        {
            private IDictionary<string, string> _unitsHash = new Dictionary<string, string>
            {
                { "0", "" },
                { "1", "one" },
                { "2", "two" },
                { "3", "three" },
                { "4", "four" },
                { "5", "five" },
                { "6", "six" },
                { "7", "seven" },
                { "8", "eight" },
                { "9", "nine" }
            };

            private IDictionary<string, string> _teensHash = new Dictionary<string, string>
            {
                { "10", "ten" },
                { "11", "eleven" },
                { "12", "twelve" },
                { "13", "thirteen" },
                { "14", "fourteen" },
                { "15", "fifteen" },
                { "16", "sixteen" },
                { "17", "seventeen" },
                { "18", "eighteen" },
                { "19", "nineteen" }
            };

            private IDictionary<string, string> _tensHash = new Dictionary<string, string>
            {
                { "2", "twenty" },
                { "3", "thirty" },
                { "4", "fourty" },
                { "5", "fifty" },
                { "6", "sixty" },
                { "7", "seventy" },
                { "8", "eighty" },
                { "9", "ninety" }
            };

            public string solution(string amount)
            {
                List<string> result = new List<string>();
                string fullAmountWithOutCurrency = amount.Substring(1);
                string[] split = fullAmountWithOutCurrency.Split('.');
                string rands = split[0];
                string cents = string.Empty;

                if (split.Length > 1)
                {
                    cents = split[1];
                }

                for (int i = 0, step = rands.Length - 1; i < rands.Length;)
                {
                    string digit = rands[i].ToString();
                    int number = Convert.ToInt32(digit);
                    int currentStep = step - i;

                    if (currentStep == 1) //tens
                    {
                        if (number == 1)
                        {
                            string nextDigit = rands[i + 1].ToString();
                            result.Add(_teensHash[$"{digit}{nextDigit}"]);
                            i += 2;
                        }
                        else
                        {
                            result.Add(_tensHash[digit]);
                            i++;
                        }
                    }
                    else if (currentStep == 0) //units
                    {
                        result.Add(_unitsHash[digit]);
                        i++;
                    }

                    if (i > rands.Length - 1)
                    {
                        result.Add("Rand");
                    }
                }

                for (int i = 0, step = cents.Length - 1; i < cents.Length;)
                {
                    if (i == 0)
                    {
                        result.Add("and");
                    }

                    string digit = cents[i].ToString();
                    int number = Convert.ToInt32(digit);
                    int currentStep = step - i;

                    if (currentStep == 1) //tens
                    {
                        if (number == 1)
                        {
                            string nextDigit = cents[i + 1].ToString();
                            result.Add(_teensHash[$"{digit}{nextDigit}"]);
                            i += 2;
                        }
                        else
                        {
                            result.Add(_tensHash[digit]);
                            i++;
                        }
                    }
                    else if (currentStep == 0) //units
                    {
                        result.Add(_unitsHash[digit]);
                        i++;
                    }

                    if (i > cents.Length - 1)
                    {
                        result.Add("cents");
                    }
                }

                string fullResult = string.Join(" ", result);

                return $"{fullResult.Substring(0, 1).ToUpper()}{fullResult.Substring(1)}";
            }
        }
    }
}
