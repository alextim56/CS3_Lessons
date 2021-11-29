using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender
{
    public class EmailSendServiceClass
    {
        public EmailSendServiceClass()
        {

        }

        public bool MailSend(string _from, string _to, string _subject, string _body, string _login, string _password, IEnumerable attachments = null)
        {
            bool result = false;
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress(_from);
                // кому отправляем
                MailAddress to = new MailAddress(_to);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = _subject;
                // текст письма
                m.Body = _body;
                // письмо представляет код html
                m.IsBodyHtml = true;
                //_password = System.IO.File.ReadAllText("C:\\temp\\1.txt");
                if (attachments != null)
                {

                    foreach (object el in attachments)
                    {
                        System.Diagnostics.Debug.WriteLine(el.ToString());
                        Attachment attachment = new Attachment(el.ToString());
                        m.Attachments.Add(attachment);
                    }
                }
                //if (_login.IndexOf('@') > 0) _login = _login.Remove(_login.IndexOf('@'));

                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient(Data.SMTP_server, Data.SMTP_port);
                // логин и пароль
                smtp.Credentials = new NetworkCredential(_login, _password);
                smtp.EnableSsl = true;
                smtp.Send(m);
                result = true;
            }
            catch { }

            return result;
        }
    }
}
