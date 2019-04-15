using System.Collections.Generic;

namespace portfolio_dotnet_background.Models
{
    public class EmailMessage
    {
        public List<EmailAdress> ToAddresses  { get; set; } = new List<EmailAdress>();
        public List<EmailAdress> FromAdresses { get; set; } = new List<EmailAdress>();
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}