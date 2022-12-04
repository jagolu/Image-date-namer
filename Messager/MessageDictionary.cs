namespace ImageDater.Messager
{
    public sealed class MessageDictionary
    {
        private static MessageDictionary? _instance = null;
        private Dictionary<MessageInfoType, string> _messages = new Dictionary<MessageInfoType, string>();

        public static MessageDictionary Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new MessageDictionary();
                return _instance;
            }
        }

        public string getMessage(MessageInfoType type)
        {
            return _messages.TryGetValue(type, out string? message) ? message : String.Empty;
        }

        private MessageDictionary() { 
            Initialize();
        }

        private void Initialize()
        {
            _messages.Add(MessageInfoType.DONT_UNDERSTAND, "Sorry, I don't understand.");
            _messages.Add(MessageInfoType.DIRECTORY_PATH, "Directory path: ");
            _messages.Add(MessageInfoType.IMAGE_PATH, "Image path: ");
            _messages.Add(MessageInfoType.YES, "Y");
            _messages.Add(MessageInfoType.NO, "N");
            _messages.Add(MessageInfoType.MODE_QUESTION, "Use Directory mode? ("+
                _messages[MessageInfoType.YES]+"/"+ _messages[MessageInfoType.NO] + "): ");
            _messages.Add(MessageInfoType.WRONG_PATH, "Wrong path");
            _messages.Add(MessageInfoType.PATH_TRY_AGAIN_DIRECTORY, "Enter a path to a valid directory");
            _messages.Add(MessageInfoType.PATH_TRY_AGAIN_FILE, "Enter a path to a valid file");
            _messages.Add(MessageInfoType.CREATING_NEW_PATH, "Copying new files in ");
        }
    }
}
