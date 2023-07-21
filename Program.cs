using System;
using System.Text.RegularExpressions;


namespace Assignment_12
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Paragraph:");// Enter Paragraph you want to Insert
            string input = Console.ReadLine();

            int wordCount = CountWords(input); // function for Word  Count
            Console.WriteLine($"Word Count: {wordCount}");

            var emailAddresses = GetEmailAddresses(input);
            if (emailAddresses.Count > 0)
            {
                Console.WriteLine("Email Addresses found:");
                foreach (var email in emailAddresses)
                {
                    Console.WriteLine(email);
                }
            }
            else
            {
                Console.WriteLine("No email addresses found.");
            }

            var mobileNumbers = ExtractMobileNumbers(input);
            if (mobileNumbers.Count > 0)
            {
                Console.WriteLine("Mobile Numbers found:");
                foreach (var number in mobileNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("No mobile numbers found.");
            }

            Console.WriteLine("Enter a custom regular expression to search:");
            string customRegexPattern = Console.ReadLine();

            var customRegexMatches = PerformCustomRegexSearch(input, customRegexPattern);
            if (customRegexMatches.Count > 0)
            {
                Console.WriteLine("Custom Regex Matches found:");
                foreach (var match in customRegexMatches)
                {
                    Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine("No matches found for the custom regular expression.");
            }
            Console.ReadKey();
        }


        // this function is used for Count the words in Paragraph
        static int CountWords(string inputText)
        {
            return inputText.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        // this is used for Identify given Email Address
        static List<string> GetEmailAddresses(string inputText)
        {
            var emailRegex = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");
            var emailMatches = emailRegex.Matches(inputText);

            var emailAddresses = new List<string>();
            foreach (Match match in emailMatches)
            {
                emailAddresses.Add(match.Value);
            }

            return emailAddresses;
        }

        static List<string> ExtractMobileNumbers(string inputText)
        {
            var mobileNumberRegex = new Regex(@"\b\d{10}\b");
            var mobileNumberMatches = mobileNumberRegex.Matches(inputText);

            var mobileNumbers = new List<string>();
            foreach (Match match in mobileNumberMatches)
            {
                mobileNumbers.Add(match.Value);
            }

            return mobileNumbers;
        }

        static List<string> PerformCustomRegexSearch(string inputText, string customRegexPattern)
        {
            var customRegex = new Regex(customRegexPattern);
            var customRegexMatches = customRegex.Matches(inputText);

            var matches = new List<string>();
            foreach (Match match in customRegexMatches)
            {
                matches.Add(match.Value);
            }

            return matches;

        }

    }

}
