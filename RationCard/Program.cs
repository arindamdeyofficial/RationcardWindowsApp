using RationCard.DbSaveFireAndForget;
using RationCard.Helper;
using RationCard.HelperForms;
using RationCard.MasterDataManager;
using RationCard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RationCard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationStart();
        }
        private static void ApplicationStart()
        {
            if (!Network.IsInternetConnected)
            {
                DialogConfirm.ShowInformationDialog("Internet is not there. Please connect to internet, then open again.", "Stone Age !!");
                Application.ExitThread();
                Application.Exit();
            }
            else
            {
                //DialogConfirm.ShowInfohScreen("Application is checking your system..." + Environment.NewLine + "Please Wait");
                try
                {
                    ErrorEnum errType = ErrorEnum.Other;
                    string errMsg = string.Empty;
                    bool isSuccess = false;
                    DBSaveManager.ApplicationStartDbFetch(out errType, out errMsg, out isSuccess);
                    if (isSuccess)
                    {
                        if (User.IsSuperadmin)
                        {
                            Application.Run(new FrmUserSelector());
                        }
                        else
                        {
                            Application.Run(new FrmLogin());
                        }
                    }
                    else if (errType.Equals(ErrorEnum.IpNotAllowed))
                    {
                        DialogConfirm.ShowInformationDialog("Your IP is not allowed." + Environment.NewLine + " Please contact administrator to add your IP : " + Network.GetPublicIpAddress(), "IP not Allowed!");
                    }
                    else if (errType.Equals(ErrorEnum.MacNotAllowed))
                    {
                        DialogConfirm.ShowInformationDialog("Your machine is not allowed." + Environment.NewLine + " Please contact administrator to add your machine : " + Network.GetActiveMACAddress(), "Machine not Allowed");
                    }
                    else
                    {
                        Application.Run(new FrmSetup());
                    }                   
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
                //Thread mstDataThread = new Thread(new ThreadStart(FetchMasterData));
                //mstDataThread.Start();
            }
        }
    }    
}
