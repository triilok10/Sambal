namespace Sambal.Models
{
    public class Login
    {
        //UserName 
        public string Username { get; set; }
        //Password
        public string Password { get; set; }
        //OTP
        public string OTP { get; set; }
        //ResendOTP
        public string ResendOTP { get; set; }
        //DateOfBirth
        public DateTime DateOfBirth { get; set; }
        //Status
        public bool Status { get; set; }
        //ErrMsg
        public string ErrMsg { get; set; }
    }
}
