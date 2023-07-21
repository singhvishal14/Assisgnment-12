using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Assisgnment_12
{
    public class CustomRegexSearch
    {
        public static List<string> PerformCustomRegexSearch(string inputText, string customRegex)
        {
            List<string> matches = new List<string>();

            try
            {
                // Use regex pattern based on the custom input provided by the user.
                // The RegexOptions.Compiled flag improves performance for multiple calls to the method.
                MatchCollection regexMatches = Regex.Matches(inputText, customRegex, RegexOptions.Compiled);

                foreach (Match match in regexMatches)
                {
                    matches.Add(match.Value);
                }
            }
            catch (ArgumentException ex)
            {
                // If the user-provided regex is invalid, catch the exception and display an error message.
                Console.WriteLine("Invalid regular expression: " + ex.Message);
            }

            return matches;
        }
    }
    public class MobileNumberExtractor
    {
        public static List<string> ExtractMobileNumbers(string inputText)
        {
            List<string> mobileNumbers = new List<string>();

            // Use regex pattern to match mobile numbers with 10 digits.
            // The RegexOptions.Compiled flag improves performance for multiple calls to the method.
            MatchCollection matches = Regex.Matches(inputText, @"\b\d{10}\b", RegexOptions.Compiled);

            foreach (Match match in matches)
            {
                mobileNumbers.Add(match.Value);
            }

            return mobileNumbers;
        }
    }

    public class EmailValidator
    {
        public static bool ContainsEmail(string inputText)
        {
            // Use regex pattern to match email addresses.
            // The pattern checks for the username, @ symbol, and domain name with specific format restrictions.
            // The RegexOptions.Compiled flag improves performance for multiple calls to the method.
            MatchCollection matches = Regex.Matches(inputText, @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b", RegexOptions.Compiled);

            return matches.Count > 0;
        }
        public class WordCounter
        {
            public static int CountWords(string inputText)
            {
                if (string.IsNullOrWhiteSpace(inputText))
                    return 0;

                // Use regex pattern to match words (sequences of characters separated by spaces).
                // \b matches a word boundary, \w+ matches one or more word characters (letters, digits, underscores).
                // The RegexOptions.Compiled flag improves performance for multiple calls to the method.
                MatchCollection matches = Regex.Matches(inputText, @"\b\w+\b", RegexOptions.Compiled);

                return matches.Count;
            }
        }
        internal class Program1
        {
            static void Main(string[] args)
            {
                Console.WriteLine("enter Input as per your choice");
                string str = Console.ReadLine();
                string pattern = @"^[a-z A-Z_]*$";

                Regex regex = new Regex(pattern);
                if (regex.IsMatch(str))
                {
                    Console.WriteLine($"your line\'{str}' got readed successfully");
                }
                else
                {
                    Console.WriteLine($"your line\'{str}' containing incorrect format");
                    int wordCount = WordCounter.CountWords(str);
                    Console.WriteLine("Number of words: " + wordCount);
                    bool containsEmail = EmailValidator.ContainsEmail(str);
                    Console.WriteLine("Contains email address: " + containsEmail);
                    List<string> mobileNumbers = MobileNumberExtractor.ExtractMobileNumbers(str);

                    Console.WriteLine("Mobile numbers found:");
                    foreach (string number in mobileNumbers)
                    {
                        Console.WriteLine(number);
                    }
                    Console.Write("Enter custom regular expression: ");
                    string customRegex = Console.ReadLine();
                    Console.WriteLine("\nenter new string for custom regex");
                    string str1 = Console.ReadLine();

                    List<string> matches = CustomRegexSearch.PerformCustomRegexSearch(str1, customRegex);


                    if (matches.Count > 0)
                    {
                        Console.WriteLine("Matches found:");
                        foreach (string match in matches)
                        {
                            Console.WriteLine(match);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matches found.");
                    }

                }
                Console.ReadKey();
            }
        }
    }
}