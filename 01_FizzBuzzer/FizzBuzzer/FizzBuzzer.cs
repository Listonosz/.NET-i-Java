using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzzer
    {
        public static char[] intTochar(int input)
        {
            string str = input.ToString();
            return str.ToCharArray();
        }
        public static List<string> MillNumbers(List<int> numbers)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < numbers.Count; i++)
            {
                bool added = false;
                if (numbers[i] % 7 == 0)
                {
                    result.Add("Bazzinga");
                    break;
                    continue;
                }
                char[] foo = intTochar(numbers[i]);
                if (foo.Length > 1)
                {
                    for (int j = 0; j < foo.Length - 1; j++)
                    {
                        if (foo[j] == '3' && foo[j + 1] == '5')
                        {
                            result.Add("FizzBuzz");
                            added = true;
                            break;
                        }
                        if (foo[j] == '5')
                        {
                            if (foo[j + 1] == '3')
                            {
                                result.Add("FizzBuzz");
                                added = true;
                                break;
                            }
                            else
                            {
                                result.Add("Buzz");
                                added = true;
                                break;
                            }
                        }
                    }
                }
                if (!added)
                {
                    if (numbers[i] % 3 == 0 && numbers[i] % 5 == 0)
                    {
                        result.Add("FizzBuzz");
                        continue;
                    }
                    if (numbers[i] % 3 == 0)
                    {
                        result.Add("Fizz");
                        continue;
                    }
                    if (numbers[i] % 5 == 0)
                    {
                        result.Add("Buzz");
                        continue;
                    }
                    else
                        result.Add(numbers[i].ToString());
                }
            }
            return result;
        }
    }
}
