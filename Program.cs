using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;


    class Program
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("a1");
            var message = new MimeMessage ();
            message.From.Add (new MailboxAddress ("Alice", "alice@ampretia.co.uk"));
            message.To.Add (new MailboxAddress ("MBW", "matthew@mh-white.com"));
            message.Subject = "How you doin'?";

            message.Body = new TextPart ("plain") {
                Text = @"Hey Chandler,

I just wanted to let you know that Monica and I were going to go play some paintball, you in?

-- Joey"
            };

            using (var client = new SmtpClient ()) {
                client.Connect ("mail.ampretia.co.uk", 465, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate ("alice@ampretia.co.uk", "passw0rdWibble");

                client.Send (message);
                client.Disconnect (true);
            }
        }
    }
