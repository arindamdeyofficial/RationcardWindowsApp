﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using RationCard.Model;
using RationCard.DbSaveFireAndForget;

namespace RationCard.Helper
{
    public static class UserHelper
    {
        public static void RegisterNewUser(string name, string mobileNo, string address, string email, string profilePicPath
            , string login, string password, bool macChekRequired, string fpsCode, string fpsLiscenceNo, string mrShopNo
            , string mac, string remark, string code
            , out string successMsg)
        {
            List<MacIdAssigned> mcs = new List<MacIdAssigned>();
            successMsg = "";
            try
            {
                DBSaveManager.RegisterNewUser(name, mobileNo, address, email, profilePicPath
            , login, password, macChekRequired, fpsCode, fpsLiscenceNo, mrShopNo
            , mac, remark, code
            , out successMsg);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public static void RemoveUser(string userId, out bool isSuccess)
        {
            isSuccess = false;
            try
            {
                DBSaveManager.RemoveUser(userId, out isSuccess);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public static bool DoLogin(string userId, string password, string macId, out string msg)
        {
            bool isSuccess;
            DBSaveManager.DoLogin(userId, password, macId, out msg, out isSuccess);
            return isSuccess;
        }
    }
}
