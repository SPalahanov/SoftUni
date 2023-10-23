using System.Text;

namespace MailClient
{
    public class Mail
    {
        private string sender;
        private string receiver;
        private string body;

        public Mail(string sender, string receiver, string body)
        {
            this.Sender = sender;
            this.Receiver = receiver;
            this.Body = body;
        }

        public string Sender { get; private set; }
        public string Receiver { get; private set; }
        public string Body { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"From: {this.Sender} / To: {this.Receiver}");
            sb.AppendLine($"Message: {this.Body}");
            return sb.ToString().TrimEnd();
        }
    }
    
}
