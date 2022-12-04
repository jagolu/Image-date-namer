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

        public string getValidModifiedFolderPath(string path, bool isDirectoryMode)
        {
            string newPath = (isDirectoryMode ? path : getFileFolderPath(path))+ "\\modified";

            return validateDirectoryName(newPath);
        }

        public void createNewDirectory(string newDirectoryPath)
        {
            Directory.CreateDirectory(newDirectoryPath);    
        }

        public string getNewPath(FileData file, string newFolderPath)
        {
            String newName = getNewName(file);
            return validateFileName(newFolderPath + newName);
        }
        public string getNewPathFromName(String filePath, string newFolderPath, PathNameBehavior behaviour = PathNameBehavior.DATE_AND_HOUR)
        {
            string name = Path.GetFileNameWithoutExtension(filePath);
            string ext = Path.GetExtension(filePath);

            switch (behaviour)
            {
                case PathNameBehavior.DATE_AND_HOUR:
                    name = name.Substring(0, 10);
                    name = name.Replace("-", String.Empty);
                    break;
                case PathNameBehavior.IMG_DATE:
                    name = name.Substring(4, 8);
                    break;
            }

            return validateFileName($"{newFolderPath}{name}{ext}");
        }

        public void renameFileInNewPath(string oldFolderPath, string newFolderPath)
        {
            File.Copy(oldFolderPath, newFolderPath);
        }

        private string getFileFolderPath(string filePath)
        {
            String fullPath = Path.GetFullPath(filePath);
            String fileName = Path.GetFileName(filePath);
            return fullPath.Substring(0, fullPath.IndexOf(fileName));
        }

        private string getNewName(FileData f)
        {
            DateTime d = f.Dates.OrderBy(d => d).ToList().First();
            return d.Year.ToString() + getValidNumberString(d.Month) + getValidNumberString(d.Day) + f.extension;
        }

        private string getValidNumberString(int n)
        {
            return n < 10 ? "0" + n.ToString() : n.ToString();
        }

        private string validateDirectoryName(string path)
        {
            int modifier = 0;
            while (Directory.Exists(path + (modifier == 0 ? String.Empty : "_" + modifier.ToString())))
            {
                modifier++;
            }

            path += (modifier == 0 ? String.Empty : "_" + modifier.ToString());

            return path;
        }

        private string validateFileName(string path)
        {
            int modifier = 0;
            string pathWithoutExt = getFileFolderPath(path) + "\\" + Path.GetFileNameWithoutExtension(path);
            string ext = Path.GetExtension(path);
            while (File.Exists(pathWithoutExt + (modifier == 0 ? String.Empty : "_" + modifier.ToString()) + ext))
            {
                modifier++;
            }

            return pathWithoutExt + (modifier == 0 ? String.Empty : "_" + modifier.ToString()) + ext;
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
