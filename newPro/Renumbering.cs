using System.Text;

namespace newPro;

public class Renumbering
{
    public void NumberLiner(string path, string NewPath)
    {
        MyFileStream myFileStream = new(path);
        string text = myFileStream.ReadAllText();

        StringBuilder sb = new StringBuilder();
        int lineNumber = 1;

        StringBuilder lineBuilder = new StringBuilder();
        bool hasRealContent = false;

        for (int i = 0; i < text.Length; i++)
        {
            char chaR = text[i];

            if (chaR == '\r')
            {
                if (i + 1 < text.Length && text[i + 1] == '\n')
                {
                    i++;
                }

                if (hasRealContent)
                {
                    sb.Append($"{lineNumber}.{lineBuilder}\n");
                    lineNumber++;
                }

                lineBuilder.Clear();
                hasRealContent = false;
            }
            else if (chaR == '\n')
            {
                if (hasRealContent)
                {
                    sb.Append($"{lineNumber}.{lineBuilder}\n");
                    lineNumber++;
                }

                lineBuilder.Clear();
                hasRealContent = false;
            }
            else
            {
                if (chaR != ' ')
                {
                    hasRealContent = true;
                }

                lineBuilder.Append(chaR);
            }
        }

        if (hasRealContent)
        {
            sb.Append($"{lineNumber}.{lineBuilder}\n");
        }

        MyFileStream newFileStream = new(NewPath);
        newFileStream.WriteAllText(sb.ToString());
    }
}
