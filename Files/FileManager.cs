namespace ImageDater.Files
{
    public class FileManager
    {
        public bool existPath(string path, bool isDirectory)
        {
            return isDirectory ? Directory.Exists(path) : File.Exists(path);
        }

        public List<string> getFiles(string path)
        {
            return Directory.GetFiles(path).ToList();
        }

        public FileData getFileDataInfo(string filePath)
        {
            return new FileData
            {
                Name = Path.GetFileNameWithoutExtension(filePath),
                Path = filePath,
                extension = Path.GetExtension(filePath),
                Dates = getDates(filePath)
            };
        }

        private List<DateTime> getDates(string filePath)
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(File.GetCreationTimeUtc(filePath));
            dates.Add(File.GetLastWriteTimeUtc(filePath));

            return dates;
        }
    }
}
