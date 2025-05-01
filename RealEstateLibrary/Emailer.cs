using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary
{
    public class Emailer
    {
        private MailMessage newMail; // private MailMessage object called newMail
        private MailAddress toAddress; // private MailAddress object called toAddress
        private MailAddress fromAddress; // private MailAddress object called fromAddress
        private string mailSubject; // private string variable called mailSubject
        private string mailBody; // private string variable called mailSubject
        private bool bodyHTML = true; // private bool called bodyHTML set to ture 
        private MailPriority priority = MailPriority.Normal; // private MailPriority object called priority set to a normal mail priority
        private string mailHost = "smtp.temple.edu"; // private string called mailHost set to smtp.temple.edu

        public Emailer(string toSend, string fromSender, string subject, string body) // public Emailer initalizer that accepts four string parameters
        {
            try // try the following code
            {
                toAddress = new MailAddress(toSend); // sets the toAddress object to a new MailAddress object with the toSend variable as a parameter
                fromAddress = new MailAddress(fromSender); // sets the fromAddress object to a new MailAddress object with the fromSender variable as a parameter
                mailSubject = subject; // sets the mailSubject variable to the subject parameter
                mailBody = body; // sets the mailBody variable to the body parameter
                newMail = new MailMessage(); // sets newMail to a new MailMessage object
                newMail.To.Add(toAddress); // Adds a new To address to the newMail object with the toAddress object as a parameter
                newMail.From = fromAddress; // sets the newMail objects From to the fromAddress object
                newMail.Subject = mailSubject; // sets the newMail objects Subject to the mailSubject string
                newMail.Body = mailBody; // sets the newMail objects Body to the mailBody string
                newMail.Priority = priority; // sets the newMail ojects Prioirty to the priority MailPriority object

                SmtpClient mailClient = new SmtpClient(mailHost); // SmtpClient object called mailClient set to a new SmtPClient with the mailHost string as a parameter
                mailClient.Send(newMail); // calls the Send function of the mailClient object with the newMail object as a parameter
            }
            catch (Exception ex) // if there is an error
            {
                throw ex; // throw the error
            }
        }

    }
}
