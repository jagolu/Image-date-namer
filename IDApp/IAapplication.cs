using ImageDater.Files;
using ImageDater.Messager;

namespace ImageDater.IDApp
{
    public  class IAapplication
    {
        private readonly LineWriter _lineWriter;
        private readonly FileManager _fileManager;

        public IAapplication()
        {
            _lineWriter = new LineWriter();
            _fileManager = new FileManager();
        }

        public void run()
        {
        }
    }
}
