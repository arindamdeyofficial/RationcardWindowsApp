using RationCard.MasterDataManager;
using RationCard.Model;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Web;

namespace RationCard.Helper
{
    public static class SmsHelper
    {
        public static bool _isSendSms = SendSmsCheck();
        static string _superAdminMobiles;
        private static bool SendSmsCheck()
        {           
            return ConfigManager.GetConfigValue("SmsSendAllowed") == "TRUE";
        }
        public static bool SendSms(string msg, string numbers, out string statusMsg)
        {
            bool isSuccess = true;
            if (_isSendSms)
            {                
                statusMsg = "";
                try
                {
                    //https://control.textlocal.in/
                    //biplabhome@gmail.com
                    //Nakshal!01051987

                    string msgText = HttpUtility.UrlEncode(msg);
                    using (var wb = new WebClient())
                    {
                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/",
                            new NameValueCollection()
                            {
                            //{ "username", "biplabhome@gmail.com"},
                            //{ "password", "Nakshal!01051987"},
                            //{ "hash", "50b9a50d1bcaf6090f17daeed7ab5f76b79f023437fe556ff16a710a257e7827"},
                            {"apikey" , "DDem9k1obsM-YILTxYVltZ7HICsbaiZtmxVOfuGPev"},
                            {"numbers" , numbers},
                            {"message" , msgText},
                            {"sender" , "TXTLCL"}
                            });
                        string result = System.Text.Encoding.UTF8.GetString(response);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
            else
            {
                isSuccess = false;
                statusMsg = "Send SMS not allowed for this distributor";
            }
            return isSuccess;
        }
        public static bool NotifyDitributor(string msg, out string statusMsg)
        {
            statusMsg = "";
            if ((MasterData.Distributors != null) && (MasterData.Distributors.Data != null))
            {
                var superadmin = MasterData.Distributors.Data.Find(i => i.IsSuperAdmin);
                _superAdminMobiles = superadmin.Dist_Mobile_No + (!string.IsNullOrEmpty(superadmin.MobileNoToNotifyViaSms) ? ("," + superadmin.MobileNoToNotifyViaSms) : "");
            }
            else
            {
                _superAdminMobiles = "9830609366";
            }
            msg = "Hello " + User.Name + " !" + Environment.NewLine + msg + Environment.NewLine + "- RationcardRegister";
            return SmsHelper.SendSms(msg, _superAdminMobiles + "," + User.MobileNo + (!string.IsNullOrEmpty(User.MobileNoToNotifyViaSms) ? ("," + User.MobileNoToNotifyViaSms) : ""), out statusMsg);
        }
        public static bool NotifyAdmin(string msg, out string statusMsg)
        {
            statusMsg = "";
            if ((MasterData.Distributors != null) && (MasterData.Distributors.Data != null))
            {
                var superadmin = MasterData.Distributors.Data.Find(i => i.IsSuperAdmin);
                _superAdminMobiles = superadmin.Dist_Mobile_No + (!string.IsNullOrEmpty(superadmin.MobileNoToNotifyViaSms) ? ("," + superadmin.MobileNoToNotifyViaSms) : "");
            }
            else
            {
                _superAdminMobiles = "9830609366";
            }
            msg = "Hello " + User.Name + " !" + Environment.NewLine + msg + Environment.NewLine + "- RationcardRegister";
            return SmsHelper.SendSms(msg, _superAdminMobiles, out statusMsg);
        }
    }
}
