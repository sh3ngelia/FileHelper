namespace newPro
{
    public class Counting
    {
        private readonly string _path;
        private readonly Dictionary<char, int> _charCount = new();
        private int _totalChars = 0;

        public Counting(string path)
        {
            _path = path;
        }

        public int AnalyzeAndCountWords()
        {
            MyFileStream myFileStream = new(_path);
            string text = myFileStream.ReadAllText();

            foreach (char i in text)
            {
                if (IsLetterOrDigit(i))
                {
                    _totalChars++;
                    if (ContainsKey(_charCount, i)) 
                        _charCount[i]++;
                    else
                        _charCount[i] = 1;
                }
            }

            int wordCount = CountWords(text);
            return wordCount;
        }

        private int CountWords(string text)
        {
            int wordCount = 0;
            bool inWord = false;

            foreach (char i in text)
            {
                if (IsLetterOrDigit(i))
                {
                    if (!inWord)
                        inWord = true;
                }
                else
                {
                    if (inWord)
                    {
                        wordCount++;
                        inWord = false;
                    }
                }
            }

            if (inWord)
                wordCount++;

            return wordCount;
        }

        private bool IsLetterOrDigit(char i)
        {
            return (i >= 'A' && i <= 'Z') ||
                   (i >= 'a' && i <= 'z') ||
                   (i >= '0' && i <= '9');
        }
        private bool ContainsKey(Dictionary<char, int> dict, char key)
        {
            foreach (var i in dict.Keys)
            {
                if (i == key)
                    return true;
            }
            return false;
        }


        public Dictionary<char, int> GetCharCounts() => _charCount;
        public int GetTotalChars() => _totalChars;
    }
}
