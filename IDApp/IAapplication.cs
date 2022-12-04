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
        }

        private void getMode()
        {
            _mode = PathMode.DEFAULT;

            bool isDirectoryMode = _lineWriter.isDirectoryMode();
            _mode = isDirectoryMode ? PathMode.DIRECTORY_MODE : PathMode.FILE_MODE;
        }
        private bool isDirectoryModeSelected()
        {
            return _mode == PathMode.DIRECTORY_MODE;
        }
    }
}
