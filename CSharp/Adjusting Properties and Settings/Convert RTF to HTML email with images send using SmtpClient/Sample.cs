using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Collections.Generic;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string rtfFile = Path.GetFullPath(@"..\..\images.rtf");

            // 1. Convert RTF to HTML and place all images to list
            string rtfString = File.ReadAllText(rtfFile);
            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();
            r.ImageStyle.IncludeImageInHtml = false;
            List<SautinSoft.RtfToHtml.SautinImage> imageList = new List<SautinSoft.RtfToHtml.SautinImage>();

            // 2. After launching this method we'll get our RTF document in HTML format
            // and list of all images.
            r.OpenRtf(rtfString);
            string htmlString = String.Empty;
			r.ToHtml(out htmlString, imageList);

            // 3. Create HTML email
            string from = "bob@bobsite.com";            
            string to = "john@johnsite.com";            
            string subject = "This is a testing email from Bob to John using SmtpClient";

            MailMessage emailMessage = new MailMessage();
            emailMessage.From = new MailAddress(from);
            emailMessage.To.Add(to);
            emailMessage.Subject = subject.Replace("\r\n", "");

            // 4. Attach images to email
            System.Net.Mail.AlternateView altView = AlternateView.CreateAlternateViewFromString(htmlString, null, "text/html");

            foreach (SautinSoft.RtfToHtml.SautinImage simg in imageList)
            {
                if (simg.Img != null)
                {
                    LinkedResource lr = null;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    simg.Img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    if (ms != null && ms.Position > 0)
                        ms.Position = 0;
                    lr = new LinkedResource(ms);
                    lr.ContentId = simg.Cid;
                    altView.LinkedResources.Add(lr);
                }
            }
            emailMessage.AlternateViews.Add(altView);

            // 5. Send the message using email account
            string userName = "bobuser";
            string userPassword = "bobpassword";

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            //client.UseDefaultCredentials = false;

            // Some smtp servers doesn't require credentials, therefore
            // you may set: client.UseDefaultCredentials = false;
            // and remove the line: client.Credentials = new NetworkCredential(userName, userPassword);

            client.Credentials = new NetworkCredential(userName, userPassword);
            client.Host = "smtpout.bobsite.com";
            
            // In the real example in case of the correct host, uncomment the line below:
            //client.Send(emailMessage);
            Console.WriteLine("The message has been sent!");
            Console.ReadKey();
        }
    }
}
