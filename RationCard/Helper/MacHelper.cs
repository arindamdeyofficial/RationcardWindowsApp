using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using RationCard.Model;

namespace RationCard.Helper
{
    public static class MacHelper
    {
        public static List<MacIdAssigned> OperateMacId(string distId, string mac, string macIdType, string startFormName, string remark, string operation, out bool isSuccess)
        {
            List<MacIdAssigned> mcs = new List<MacIdAssigned>();
            isSuccess = false;
            try
            {
                mcs = DbSaveFireAndForget.DBSaveManager.GetMacAddrsFromDb(distId, mac, macIdType, startFormName, remark, operation, out isSuccess);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return mcs;
        }
    }
}
