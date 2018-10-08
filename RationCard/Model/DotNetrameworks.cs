using RationCard.Helper;
using RationCard.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RationCard.Model
{
    public static class DotNetrameworks
    {
        private static FrameworkVersion _ver;
        static DotNetrameworks()
        {
            AllFrameworkVersions = FrameworkVersionHelper.GetVersionFromRegistry();
            _ver = FindLatestFramework();
        }
        public static List<FrameworkVersion> AllFrameworkVersions { get; set; }
        public static string LatestFrameworkVersionName
        {
            get
            {
                return _ver.Name;
            }
        }
        public static FrameworkVersion LatestFrameworkVersion
        {
            get
            {
                return _ver;
            }
        }
        public static bool IsCompatible { get; set; }
        private static FrameworkVersion FindLatestFramework()
        {            
            FrameworkVersion selectedFramework = null;
            FrameworkVersion[] frameworkArray = AllFrameworkVersions.ToArray();
            int convertedNum = 0;
            try
            {
                for (var count = 0; count < (AllFrameworkVersions.Count() - 1); count++)
                {
                    FrameworkVersion firstFramework = null;
                    if (selectedFramework == null)
                    {
                        firstFramework = frameworkArray[count];
                    }
                    else
                    {
                        firstFramework = selectedFramework;
                    }
                    FrameworkVersion secondFramework = frameworkArray[count + 1];
                    string[] firstVersionSplit = firstFramework.Name.Split('.').ToArray();
                    string[] secondVersionSplit = secondFramework.Name.Split('.').ToArray();
                    bool greaterFound = false;

                    for (var inCount = 0; inCount < firstVersionSplit.Count(); inCount++)
                    {
                        int num1 = int.TryParse(firstVersionSplit[inCount], out convertedNum) ? convertedNum : 0;
                        int num2 = int.TryParse(secondVersionSplit[inCount], out convertedNum) ? convertedNum : 0;
                        if (num1 == num2)
                        {
                            continue;
                        }
                        else
                        {
                            selectedFramework = (num1 > num2) ? firstFramework : secondFramework;
                            greaterFound = true;
                            break;
                        }
                    }
                    if (!greaterFound)
                    {
                        int sp1 = int.TryParse(firstFramework.Sp, out convertedNum) ? convertedNum : 0;
                        int sp2 = int.TryParse(secondFramework.Sp, out convertedNum) ? convertedNum : 0;
                        if (sp1 != sp2)
                        {
                            selectedFramework = (sp1 > sp2) ? firstFramework : secondFramework;
                        }
                        else
                        {
                            selectedFramework = (firstFramework.SubKeyName == "Full") ? firstFramework : secondFramework;
                        }
                    }
                }
                //find out framework greater than 4.5
                string[] versionSplit = selectedFramework.Name.Split('.').ToArray();
                for (var c = 0; c < 1; c++)
                {
                    int majorVer = int.TryParse(versionSplit[0], out convertedNum) ? convertedNum : 0;
                    int subVer = int.TryParse(versionSplit[1], out convertedNum) ? convertedNum : 0;
                    if ((majorVer >= 4) && (subVer >= 5))
                    {
                        IsCompatible = true;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
            return selectedFramework;
        }
    }
}
