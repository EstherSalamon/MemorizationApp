namespace MemorizationApp.Data.Classes
{
    public class CompareTextData
    {
        public string RecitalText { get; set; }
        public string CompareText { get; set; }
    }

    public class CompareTextResponse: FormResponse
    {
        public CompareTextData Data { get; set; }
    }
}