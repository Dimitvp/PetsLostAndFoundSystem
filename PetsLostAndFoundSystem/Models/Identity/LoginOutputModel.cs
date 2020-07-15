namespace PetsLostAndFoundSystem.Models.Identity
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, int reporterId)
        {
            this.Token = token;
            this.ReporterId = reporterId;
        }

        public int ReporterId { get; }

        public string Token { get; }
    }
}
