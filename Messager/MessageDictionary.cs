namespace ImageDater.Messager
{
    public sealed class MessageDictionary
    {
        private static MessageDictionary? _instance = null;
        public static MessageDictionary Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new MessageDictionary();
                return _instance;
            }
        }
        private MessageDictionary() { 
            Initialize();
        }

        private void Initialize()
        {
        }
    }
}
