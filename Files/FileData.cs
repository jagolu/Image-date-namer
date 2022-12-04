namespace ImageDater.Files
{
    public class FileData
    {
        public string Name { get; set; } = String.Empty;
        public string Path { get; set; } = String.Empty;
        public string extension { get; set; } = String.Empty;
        public List<DateTime> Dates { get; set; } = new List<DateTime>();
    }
}
