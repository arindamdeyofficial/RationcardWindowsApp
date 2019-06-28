using System;
using System.Windows.Forms;
using System.Net.Mail;
using RationCard.Model;
using System.Web;
using System.Net;
using RationCard.MasterDataManager;

namespace RationCard.Helper
{
    public static class EmailHelper
    {
        static string _superAdminEmail;
        public static void SendEmail(string subject, string body, string[] to, string[] cc, string[] bcc, out bool isSuccess)
        {
            try
            {                
                MailMessage mail = new MailMessage();
                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("biplabhome@gmail.com", "`28kichuJantegelekichuBoltehoi")
                };

                mail.From = new MailAddress("biplabhome@gmail.com", "Arindam Dey");

                for(var i=0; i < to.Length; i++)
                {
                    mail.To.Add(new MailAddress(to[i]));
                }
                for (var i = 0; i < cc.Length; i++)
                {
                    mail.To.Add(new MailAddress(cc[i]));
                }
                for (var i = 0; i < bcc.Length; i++)
                {
                    mail.To.Add(new MailAddress(bcc[i]));
                }

                mail.Subject = subject;
                mail.Body = body;

                smtpClient.Send(mail);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                isSuccess = false;
                Logger.LogError(ex);
            }
        }
        public static void SendErrorMail(string errMsg)
        {
            if ((MasterData.Distributors != null) && (MasterData.Distributors.Data != null))
            {
                _superAdminEmail = MasterData.Distributors.Data.Find(i => i.IsSuperAdmin).Dist_Email;
            }
            else
            {
                _superAdminEmail = "biplabhome@gmail.com";
            }
            SendErrorMailInter(errMsg, new string[] { _superAdminEmail }, new string[] { }, new string[] { });
        }
        public static void SendErrorMail(string errMsg, string[] toMailAddr, string[] ccMailAddr, string[] bccMailAddr)
        {
            SendErrorMailInter(errMsg, toMailAddr, ccMailAddr, bccMailAddr);
        }
        public static void SendErrorMail(string errMsg, string stackTrace = "")
        {
            if ((MasterData.Distributors != null) && (MasterData.Distributors.Data != null))
            {
                _superAdminEmail = MasterData.Distributors.Data.Find(i => i.IsSuperAdmin).Dist_Email;
            }
            else
            {
                _superAdminEmail = "biplabhome@gmail.com";
            }
            SendErrorMailInter(errMsg, new string[] { _superAdminEmail }, new string[] { }, new string[] { });
        }
        public static void SendErrorMail(string errMsg, string[] toMailAddr, string[] ccMailAddr, string[] bccMailAddr, string stackTrace = "")
        {
            SendErrorMailInter(errMsg, toMailAddr, ccMailAddr, bccMailAddr, stackTrace);
        }
        public static void SendErrorMail(Exception ex)
        {
            if ((MasterData.Distributors != null) && (MasterData.Distributors.Data != null))
            {
                _superAdminEmail = MasterData.Distributors.Data.Find(i => i.IsSuperAdmin).Dist_Email;
            }
            else
            {
                _superAdminEmail = "biplabhome@gmail.com";
            }
            SendErrorMailInter(ex.Message, new string[] { _superAdminEmail }, new string[] { }, new string[] { }, ex.StackTrace);
        }
        public static void SendErrorMail(Exception ex, string[] toMailAddr, string[] ccMailAddr, string[] bccMailAddr)
        {
            SendErrorMailInter(ex.Message, toMailAddr, ccMailAddr, bccMailAddr, ex.StackTrace);
        }
        public static void SendErrorMailInter(string errMsg, string[] toMailAddr, string[] ccMailAddr, string[] bccMailAddr, string stackTrace = "")
        {
            string mailBody = "";
            bool isSuccess;

            mailBody = "UserDetails:"
                + Environment.NewLine + "UserName: " + User.Name
                + Environment.NewLine + "LoginId: " + User.LoginId
                + Environment.NewLine + "MacId: " + User.MacId
                + Environment.NewLine + "Password: " + User.Password
                + Environment.NewLine + "MobileNo: " + User.MobileNo
                + Environment.NewLine + Environment.NewLine + "Time: " + DateTime.Parse(DateTime.Now.ToString()).ToString("MM-dd-yyyy HH:mm:ss")
                + Environment.NewLine + Environment.NewLine + "IP details: "
                + Environment.NewLine + "PublicIp: " + Network.GetPublicIpAddress()
                + Environment.NewLine + "ActiveMACAddress: " + Network.GetActiveMACAddress()
                + Environment.NewLine + "ActiveIP: " + Network.GetActiveIP()
                + Environment.NewLine + "ActiveGateway: " + Network.GetActiveGateway()
                + Environment.NewLine + Environment.NewLine + "Error Details: "
                + Environment.NewLine + Environment.NewLine + "Error : " + errMsg
                + Environment.NewLine + "Error Stacktrace: " + stackTrace;

            EmailHelper.SendEmail("RationcardRegistry Error for " + User.Name + " from " + Network.GetActiveMACAddress()
                , mailBody, toMailAddr, ccMailAddr, bccMailAddr, out isSuccess);
        }
        public static void SendSecurityCode(string custMailId, string securityCode, out bool isSuccess)
        {
            if ((MasterData.Distributors != null) && (MasterData.Distributors.Data != null))
            {
                _superAdminEmail = MasterData.Distributors.Data.Find(i => i.IsSuperAdmin).Dist_Email;
            }
            else
            {
                _superAdminEmail = "biplabhome@gmail.com";
            }
            isSuccess = false;
            string body = "Please use following code for registration in Rationcard Register." + Environment.NewLine 
                + Environment.NewLine + securityCode;
            EmailHelper.SendEmail("Rationcardregister-new user registration security code", body
                , new string[] { custMailId }
                , new string[] { _superAdminEmail }
                , new string[] { }, out isSuccess);
        }
        
    }
}
