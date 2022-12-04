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
            string modifiedFolderPath = createModifiedFolder(path);
            renamingFiles(files, modifiedFolderPath);
        }

        public void run2(PathNameBehavior behavior)
        {
            getMode();
            string path = getPath();
            List<String> files = (isDirectoryModeSelected() ? getFilesFromDirectory(path) : getFileDataFromFile(path)).
                Select(x => x.Path).ToList();
            string modifiedFolderPath = createModifiedFolder(path);
            renamingFilesFromName(files, modifiedFolderPath, behavior);
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

        private string createModifiedFolder(string path)
        {
            string newPath = _fileManager.getValidModifiedFolderPath(path, isDirectoryModeSelected());
            _lineWriter.creatingNewDirectory(newPath);
            _fileManager.createNewDirectory(newPath);  

            return newPath + "\\";
        }

        private void renamingFiles(List<FileData> files, string newFolderPath)
        {
            files.ForEach(f =>
            {
                string newPath = _fileManager.getNewPath(f, newFolderPath);
                _lineWriter.renameFile(f.Path, newPath);
                _fileManager.renameFileInNewPath(f.Path, newPath);
            });
        }

        private void renamingFilesFromName(List<string> pathFiles, string newFolderPath, PathNameBehavior behavior)
        {
            pathFiles.ForEach(f =>
            {
                string newPath = _fileManager.getNewPathFromName(f, newFolderPath, behavior);
                _lineWriter.renameFile(f, newPath);

                _fileManager.renameFileInNewPath(f, newPath);
            });
        }

        private bool isDirectoryModeSelected()
        {
            return _mode == PathMode.DIRECTORY_MODE;
        }
    }
}
