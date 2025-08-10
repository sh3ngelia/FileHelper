using System.Text;

namespace newPro;

internal class MyFileStream : MyStream
{
    public MyFileStream(string inputFilePath) : base(inputFilePath)
    {
    }

    public string ReadAllText()
    {
        Stream fileStream = new FileStream(_inputFilePath, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        string text = GetString(data);
        fileStream.Close();
        return text;
    }

    public void WriteAllText(string text, FileMode fileMode = FileMode.Create)
    {
        Stream fileStream = new FileStream(_inputFilePath, fileMode);
        byte[] data = GetBytes(text);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    public void AppendAllText(string text)
    {
        Stream fileStream = new FileStream(_inputFilePath, FileMode.Append);
        byte[] data = GetBytes(text);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    public static string GetString(byte[] data)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sb.Append((char)data[i]);
        }
        return sb.ToString();
    }

    static byte[] GetBytes(string str)
    {
        byte[] data = new byte[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            data[i] = (byte)str[i];
        }
        return data;
    }


}
