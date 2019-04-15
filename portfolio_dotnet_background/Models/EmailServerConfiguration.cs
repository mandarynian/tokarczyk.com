namespace portfolio_dotnet_background.Models
{
    public class EmailServerConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }

        public EmailServerConfiguration(int _smtpPort = 465)
        {
            SmtpPort = _smtpPort;
        }
    }
}