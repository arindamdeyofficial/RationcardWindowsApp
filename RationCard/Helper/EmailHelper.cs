using System;
using System.Windows.Forms;
using System.Net.Mail;
using RationCard.Model;
using System.Web;
using System.Net;
using RationCard.MasterDataManager;
using System.Configuration;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Label = Google.Apis.Gmail.v1.Data.Label;

namespace RationCard.Helper
{
    public static class EmailHelper
    {
        static string _superAdminEmail;

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        static string ApplicationName = "Gmail API .NET Quickstart";

        public static void SendEmail(string subject, string body, string[] to, string[] cc, string[] bcc, out bool isSuccess)
        {
            //https://developers.google.com/gmail/api/quickstart/dotnet
            try
            {
                //UserCredential credential;

                //using (var stream =
                //    new FileStream("credentials.json", FileMode.OpenOrCreate, FileAccess.Read))
                //{
                //    // The file token.json stores the user's access and refresh tokens, and is created
                //    // automatically when the authorization flow completes for the first time.
                //    string credPath = "token.json";
                //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                //        GoogleClientSecrets.FromStream(stream).Secrets,
                //        Scopes,
                //        "user",
                //        CancellationToken.None,
                //        new FileDataStore(credPath, true)).Result;
                //    Logger.LogInfo("Credential file saved to: " + credPath);

                //    // Create Gmail API service.
                //    var service = new GmailService(new BaseClientService.Initializer()
                //    {
                //        HttpClientInitializer = credential,
                //        ApplicationName = ApplicationName,
                //    });

                //    // Define parameters of request.
                //    UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");
                //    // List labels.
                //    IList<Label> labels = request.Execute().Labels;
                //    Console.WriteLine("Labels:");
                //    if (labels != null && labels.Count > 0)
                //    {
                //        foreach (var labelItem in labels)
                //        {
                //            Console.WriteLine("{0}", labelItem.Name);
                //        }
                //    }
                //    else
                //    {
                //        Console.WriteLine("No labels found.");
                //    }
                //    Console.Read();
                //}

                MailMessage mail = new MailMessage();
                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("biplabhome@gmail.com",
                    SecurityEncrypt.Decrypt(ConfigurationManager.AppSettings["MailSecretKey"].ToString(), "nakshal")
                    )
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
                //MessageBox.Show(ex.Message);
                isSuccess = false;
                //Logger.LogError(ex);
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
