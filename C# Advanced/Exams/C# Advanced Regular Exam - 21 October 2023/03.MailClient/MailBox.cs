using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public int Capacity { get; private set; }
        public List<Mail> Inbox { get; private set; }
        public List<Mail> Archive { get; private set; }
        public int GetCount => Inbox.Count;

        public void IncomingMail(Mail mail)
        {
            if (GetCount < Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender) => Inbox.Remove(Inbox.FirstOrDefault(s => s.Sender == sender));

        public int ArchiveInboxMessages()
        {
            foreach (var mail in Inbox)
            {
                Archive.Add(mail);
            }

            Inbox.Clear();
            return Archive.Count;
        }

        public string GetLongestMessage()
        {
            Mail longestMail = Inbox.OrderByDescending(m => m.Body.Length).FirstOrDefault();

            if (longestMail != null)
            {
                return longestMail.ToString();
            }

            return string.Empty;
        }

        public string? InboxView()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Inbox:");

            foreach (var mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
