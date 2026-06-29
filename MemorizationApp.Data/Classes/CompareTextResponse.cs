namespace MemorizationApp.Data.Classes
{
    public class DiffPieces
    {
        public required string Text { get; set; }
        public bool IsDiff { get; set; }
    }

    public class CompareTextData
    {
        public List<DiffPieces> RecitalText { get; set; }
        public List<DiffPieces> CompareText { get; set; }
    }

    public class CompareTextResponse: FormResponse
    {
        public CompareTextData Data { get; set; }
    }
}