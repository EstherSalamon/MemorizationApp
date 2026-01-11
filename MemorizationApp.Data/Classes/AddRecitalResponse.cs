namespace MemorizationApp.Data.Classes
{
    public class AddRecitalData
    {
        public int RecitalId { get; set; }
    }

    public class AddRecitalResponse: FormResponse
    {
        public AddRecitalData Data { get; set; }
    }
}