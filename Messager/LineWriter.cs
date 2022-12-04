namespace ImageDater.Messager
{
    public class LineWriter
    {
        public LineWriter() { }

        public bool isDirectoryMode()
        {
            string answer = String.Empty;
            string yes = MessageDictionary.Instance.getMessage(MessageInfoType.YES);
            string no = MessageDictionary.Instance.getMessage(MessageInfoType.NO);

            while((!String.Equals(answer, yes) && !String.Equals(answer, no)) || String.IsNullOrEmpty(answer))
            {
                Console.WriteLine(MessageDictionary.Instance.getMessage(MessageInfoType.MODE_QUESTION));
                answer = Console.ReadLine() ?? String.Empty;
                answer = answer.ToUpper();

                if((!String.Equals(answer, yes) && !String.Equals(answer, no)) || String.IsNullOrEmpty(answer))
                {
                    Console.WriteLine(MessageDictionary.Instance.getMessage(MessageInfoType.DONT_UNDERSTAND));
                }
            }

            return answer.Equals(yes);  
        }

        public string getPathMessage(bool isDirectory = true)
        {
            Console.WriteLine(MessageDictionary.Instance.getMessage(
                isDirectory ? MessageInfoType.DIRECTORY_PATH : MessageInfoType.IMAGE_PATH));

            return Console.ReadLine() ?? String.Empty;
        }

        public void wrongPathMessage(bool isDirectory = true)
        {
            Console.WriteLine(MessageDictionary.Instance.getMessage(MessageInfoType.WRONG_PATH));
            Console.WriteLine(MessageDictionary.Instance.getMessage(
                isDirectory ? MessageInfoType.PATH_TRY_AGAIN_DIRECTORY : MessageInfoType.PATH_TRY_AGAIN_FILE));
        }
    }
}
