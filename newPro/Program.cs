using System.Globalization;
using System.Text;
using static newPro.Counting;

namespace newPro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. FileNumbersSum 
            //string path = @"D:\forTests\sum.txt";
            //FileNumbersSum fileNumbersSum = new FileNumbersSum(path);
            //int sum = fileNumbersSum.NumbersSum(path);
            //Console.WriteLine("Sum: " + sum);


            // 2. Renumbering
            //Renumbering renumbering = new Renumbering();
            //string path = @"D:\forTests\Renumbering.txt";
            //string newPath = @"D:\forTests\NewRenum.txt";
            //renumbering.NumberLiner(path, newPath);

            // 3. Counting
            string filePath = @"D:\forTests\for3.txt";
            Counting analyzer = new Counting(filePath);
            int wordCount = analyzer.AnalyzeAndCountWords();

            Console.WriteLine($"Words: {wordCount}");
            Console.WriteLine($"Total chars: {analyzer.GetTotalChars()}");

            var charCounts = analyzer.GetCharCounts();
            foreach (var i in charCounts)
            {
                Console.WriteLine($"{i.Key} - {i.Value}");
            }

        }


    }
}

