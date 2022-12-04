namespace ImageDater.Files
{
    public class FileManager
    {
        public bool existPath(string path, bool isDirectory)
        {
            return isDirectory ? Directory.Exists(path) : File.Exists(path);
        }
    }
}
