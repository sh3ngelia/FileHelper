namespace newPro
{
    // validaciis shemowmeba
    internal abstract class MyStream
    {
        protected readonly string _inputFilePath;

        protected MyStream(string inputFilePath)
        {
            ArgumentNullException.ThrowIfNull(inputFilePath, nameof(inputFilePath));
            if (!File.Exists(inputFilePath)) throw new FileNotFoundException("File not found", inputFilePath);
            _inputFilePath = inputFilePath;
        }
    }
}
