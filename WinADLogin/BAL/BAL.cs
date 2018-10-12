using System;
using System.Configuration;
using System.DirectoryServices;

namespace WinADLogin.Models.BAL
{
    public class BAL
    {
        private static BAL Instance = null;
        private static object Lockthis = new object();
        private BAL()
        {
        }
        public static BAL Getstates()
        {
            lock (Lockthis)
            {
                if (BAL.Instance == null)
                {
                    Instance = new BAL();
                }
            }
            return Instance;
        }
        public bool LogonValid(string UserName, string Password)
        {
            string domain = ConfigurationManager.AppSettings["DomainName"];
            DirectoryEntry DEntry = new DirectoryEntry(null, domain + "\\" + UserName, Password);
            try
            {
                object Nobject = DEntry.NativeObject;
                DirectorySearcher DSearch = new DirectorySearcher(DEntry);
                DSearch.Filter = "samaccountname=" + UserName;
                DSearch.PropertiesToLoad.Add("cn");
                SearchResult sr = DSearch.FindOne();
                if (sr == null) throw new Exception();
                return true;
            }
            catch (Exception EX)
            {
                return false;
            }
        }
        public string GetUserFirstName(string Domain, string UserName)
        {
            System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.DirectoryServices.DirectoryEntry ADEntry = new System.DirectoryServices.DirectoryEntry("WinNT://" + Domain + "/" + UserName);
            // System.DirectoryServices.DirectoryEntry ADEntry = new System.DirectoryServices.DirectoryEntry("LDAP://" + domine + "/" + username);
            return ADEntry.Properties["FullName"].Value.ToString();
        }
    }
}