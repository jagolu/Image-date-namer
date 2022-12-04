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

        private string getFileFolderPath(string filePath)
        {
            String fullPath = Path.GetFullPath(filePath);
            String fileName = Path.GetFileName(filePath);
            return fullPath.Substring(0, fullPath.IndexOf(fileName));
        }

        public string getValidModifiedFolderPath(string path, bool isDirectoryMode)
        {
            string newPath = (isDirectoryMode ? path : getFileFolderPath(path))+ "//modified";
            int modifier = 0;
            while (Directory.Exists(newPath + (modifier == 0 ? String.Empty : modifier.ToString())))
            {
                modifier++;
            }

            newPath += (modifier == 0 ? String.Empty : modifier.ToString());

            return newPath;
        }

        public void createNewDirectory(string newDirectoryPath)
        {
            Directory.CreateDirectory(newDirectoryPath);    
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
