using System.Text;

namespace newPro
{
    public class FileNumbersSum
    {
        public string FilePath { get; set; }

        public FileNumbersSum(string filePath)
        {
            FilePath = filePath;
        }

        public int NumbersSum(string path)
        {
            MyFileStream myFileStream = new(FilePath);
            string wholeText = myFileStream.ReadAllText();

            int sum = 0;
            StringBuilder numberBuilder = new();

            foreach (char i in wholeText)
            {
                if (i == '\r' || i == '\n')
                {
                    if (numberBuilder.Length > 0)
                    {
                        if (int.TryParse(numberBuilder.ToString(), out int number))
                            sum += number;

                        numberBuilder.Clear();
                    }
                }
                else
                {
                    numberBuilder.Append(i);
                }
            }

            if (numberBuilder.Length > 0 && int.TryParse(numberBuilder.ToString(), out int lastNumber))
            {
                sum += lastNumber;
            }

            return sum;
        }
    }
}
