﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HastaRandevuKayit.BusinessLogic.Services
{
    public class EmailService
    {
        public bool SendMail(string receiverMail, string body)
        {
            try
            {
                // SMTP sunucusu bilgileri
                string smtpAddress = "smtp.office365.com";
                int portNumber = 587;
                bool enableSSL = true;

                // Gönderenin ve alıcının e-posta bilgileri
                string emailFrom = "hastanerandevukayit@hotmail.com";
                string password = "H000R000K";

                using MailMessage mail = new();
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(receiverMail);
                mail.Subject = "Hasta Randevu Sistemi";
                mail.Body = body;
                //mail.IsBodyHtml = true; // E-posta içeriğinin HTML olup olmadığını belirtir

                using SmtpClient smtp = new(smtpAddress, portNumber);
                smtp.Credentials = new NetworkCredential(emailFrom, password);
                smtp.EnableSsl = enableSSL;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
