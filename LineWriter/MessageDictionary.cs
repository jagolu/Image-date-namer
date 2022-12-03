namespace ImageDater.LineWriter
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

        private MessageDictionary() { }

        public string getMessage(MessageInfoType type)
        {
            return _messages[type];
        }

        public void Initialize()
        {
            _messages.Add(MessageInfoType.DONT_UNDERSTAND, "Sorry, I don't understand.");
            _messages.Add(MessageInfoType.DIRECTORY_PATH, "Directory path: ");
            _messages.Add(MessageInfoType.IMAGE_PATH, "Image path: ");
            _messages.Add(MessageInfoType.MODE_QUESTION, "Use Directory mode? (Y/N): ");
        }
    }
}
