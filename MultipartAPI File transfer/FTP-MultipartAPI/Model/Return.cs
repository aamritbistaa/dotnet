namespace FTP_MultipartAPI.Model
{
    public class Return
    {
        public string message { get; set; }
        public int return_code { get; set;}

        public List<Users>? data { get; set; }
    }
}
