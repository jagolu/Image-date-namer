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
            _messages.Add(MessageInfoType.YES, "Y");
            _messages.Add(MessageInfoType.NO, "N");
            _messages.Add(MessageInfoType.MODE_QUESTION, "Use Directory mode? ("+
                _messages[MessageInfoType.YES]+"/"+ _messages[MessageInfoType.NO] + "): ");
        }
    }
}
