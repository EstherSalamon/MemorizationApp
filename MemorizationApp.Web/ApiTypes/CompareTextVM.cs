namespace MemorizationApp.Web.ApiTypes
{
    public class CompareTextVM
    {
        public int RecitalId { get; set; }
        public string CompareText { get; set; }
        public List<CompareType> Preferences {get; set;}
    }
}
