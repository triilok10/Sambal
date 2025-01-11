namespace Sambal.Models
{
    public class Web
    {

        //CategoryID
        public int CategoryID { get; set; }
        //CategoryTitle
        public string CategoryTitle { get; set; }
        //CategoryDescription
        public string CategoryDescription { get; set; }
        //CategoryImage
        public IFormFile CategoryImage { get; set; }
        //Status
        public bool Status { get; set; }
        //Message
        public string Message { get; set; }
    }
}
