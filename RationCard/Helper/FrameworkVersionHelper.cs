using Microsoft.Win32;
using RationCard.Model;
using System;
using System.Collections.Generic;

namespace RationCard.Helper
{
    public static class FrameworkVersionHelper
    {
        public static List<FrameworkVersion> GetVersionFromRegistry()
        {
            var frameworkVersions = new List<FrameworkVersion>();
            try
            {
                FrameworkVersion versionName = new FrameworkVersion();
                // Opens the registry key for the .NET Framework entry.
                using (RegistryKey ndpKey =
                    RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").
                    OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                {
                    // As an alternative, if you know the computers you will query are running .NET Framework 4.5 
                    // or later, you can use:
                    // using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                    // RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                    foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                    {
                        if (versionKeyName.StartsWith("v"))
                        {
                            RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                            string name = (string)versionKey.GetValue("Version", "");
                            string sp = versionKey.GetValue("SP", "").ToString();
                            string install = versionKey.GetValue("Install", "").ToString();
                            if (install == "") //no install info, must be later.
                            {
                                versionName.VersionKeyName = versionKeyName;
                                versionName.Name = name;
                            }
                            else
                            {
                                if (sp != "" && install == "1")
                                {
                                    versionName.VersionKeyName = versionKeyName;
                                    versionName.Name = name;
                                    versionName.Sp = sp;
                                }

                            }
                            if (name != "")
                            {
                                frameworkVersions.Add(versionName);
                                versionName = new FrameworkVersion();
                                continue;
                            }
                            foreach (string subKeyName in versionKey.GetSubKeyNames())
                            {
                                RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                                name = (string)subKey.GetValue("Version", "");
                                if (name != "")
                                    sp = subKey.GetValue("SP", "").ToString();
                                install = subKey.GetValue("Install", "").ToString();
                                if (install == "") //no install info, must be later.
                                {
                                    versionName.VersionKeyName = versionKeyName;
                                    versionName.Name = name;
                                    frameworkVersions.Add(versionName);
                                }
                                else
                                {
                                    if (sp != "" && install == "1")
                                    {
                                        versionName.SubKeyName = subKeyName;
                                        versionName.Name = name;
                                        versionName.Sp = sp;
                                    }
                                    else if (install == "1")
                                    {
                                        versionName.SubKeyName = subKeyName;
                                        versionName.Name = name;

                                    }
                                }
                                frameworkVersions.Add(versionName);
                                FrameworkVersion tmpVersionName = new FrameworkVersion();
                                tmpVersionName.VersionKeyName = versionName.VersionKeyName;
                                tmpVersionName.Sp = versionName.Sp;
                                versionName = new FrameworkVersion();
                                versionName = tmpVersionName;
                            }
                            versionName = new FrameworkVersion();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return frameworkVersions;
        }
    }
}
