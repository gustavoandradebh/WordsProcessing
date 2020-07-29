using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordsProcessing
{
    class Program
    {   /// <summary>
        /// https://www.codepile.net/pile/d0WP7DQg
        /// # Words processing
        /// The given text:
        ///«It used to take hours or days to do something similar in the past.How is it possible to deploy, deploy and configure, 
        ///configure and connect and finally build the back-end cloud services as well as configure the front-end so quickly with so much less lines of code?»
        ///1. Implement the method, which will enumerate all the (unique) words in the string, and sort them alphabetically
        ///SAs: case-sensitive/case-insensitive
        /// </summary>
        static void Main(string[] args)
        {
            var text = "It used to take hours or days to do something similar in the past. How is it possible to deploy, deploy and configure, configure and connect and finally build the back-end cloud services as well as configure the front-end so quickly with so much less lines of code?";

            var onlyWords = Regex.Replace(text, @"[\p{P}-[()\-]]", "");
            var groupedWords = onlyWords.Split(" ").GroupBy(x => x, StringComparer.OrdinalIgnoreCase);
            var orderedWords = groupedWords.OrderBy(x => x.Key);

            foreach (var word in orderedWords)
            {
                Console.WriteLine(word.Key);
            }

            Console.WriteLine(ToCamelCase("late_comer_"));
            Console.WriteLine(ToCamelCase("patient_bed_level_code"));

            Console.ReadKey();
        }


        /// <summary>
        ///Implement ToCamelCase() method that converts snake_case to camelCase.
        ///Note:
        ///* test input will always be appropriately formatted snake_case
        ///* you can use Char.ToUpper()
        /// </summary>
        /// <param name="text"></param>
        /// <returns>camelCaseWord</returns>
        private static string ToCamelCase(string text)
        {
            StringBuilder camelCase = new StringBuilder();
            var arr = text.Split("_", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arr.Length; i++)
            {
                var word = arr[i];
                var firstLetter = (i == 0) ? Char.ToLower(word[0]) : Char.ToUpper(word[0]);

                var lastLetters = (word.Length > 1) ? word.Substring(1) : "";

                var upperCaseWord =  firstLetter + lastLetters;
                camelCase.Append(upperCaseWord);
            }

            return camelCase.ToString();
        }
    }
}
