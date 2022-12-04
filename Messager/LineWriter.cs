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
    }
}
