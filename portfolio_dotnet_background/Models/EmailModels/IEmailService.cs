namespace portfolio_dotnet_background.Models
{
    public interface IEmailService
    {
        void Send(EmailMessage message);   
    }
}