namespace MemorizationApp.Data.Classes
{
    public class CompareTextRequest
    {
        public int RecitalId { get; set; }
        public string CompareText { get; set; }
        public List<CompareType> Preferences {get; set;}
    }
}