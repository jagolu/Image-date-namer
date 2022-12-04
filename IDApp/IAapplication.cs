using ImageDater.Files;
using ImageDater.Messager;

namespace ImageDater.IDApp
{
    public  class IAapplication
    {
        private PathMode _mode;
        private readonly LineWriter _lineWriter;
        private readonly FileManager _fileManager;

        public IAapplication()
        {
            _mode = PathMode.DEFAULT;
            _lineWriter = new LineWriter();
            _fileManager = new FileManager();
        }

        public void run()
        {
            getMode();
            string path = getPath();
            List<FileData> files = isDirectoryModeSelected() ? getFilesFromDirectory(path) : getFileDataFromFile(path);

        }

        private void getMode()
        {
            _mode = PathMode.DEFAULT;

            bool isDirectoryMode = _lineWriter.isDirectoryMode();
            _mode = isDirectoryMode ? PathMode.DIRECTORY_MODE : PathMode.FILE_MODE;
        }

        private string getPath()
        {
            string path;
            bool correctPath;
            bool isDirectory = isDirectoryModeSelected();

            do
            {
                path = _lineWriter.getPathMessage(isDirectory);
                correctPath = _fileManager.existPath(path, isDirectory);

                if (!correctPath) _lineWriter.wrongPathMessage(isDirectory);

            } while (!correctPath);

            return path;
        }

        private List<FileData> getFilesFromDirectory(string path)
        {
            List<string> files = _fileManager.getFiles(path);
            List<FileData> filesData = new List<FileData>();
            
            files.ForEach(f => filesData.Add(_fileManager.getFileDataInfo(f)));

            return filesData;
        }

        private List<FileData> getFileDataFromFile(string filePath)
        {
            List<FileData> filesData = new List<FileData>();

            filesData.Add(_fileManager.getFileDataInfo(filePath));

            return filesData;
        }
        private bool isDirectoryModeSelected()
        {
            return _mode == PathMode.DIRECTORY_MODE;
        }
    }
}
