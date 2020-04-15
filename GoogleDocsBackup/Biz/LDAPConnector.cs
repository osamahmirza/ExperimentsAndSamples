using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices.AccountManagement;
using System.Configuration;

namespace DocumentListAPI.Entities
{
    public class LDAPConnector
    {
        private static PrincipalContext _PC;
        private static string _Localserver;
        private static string _Localroot;
        
        //Following two variables are temporary
        private static string _UserName;
        private static string _Password;

        public static PrincipalContext Connect(ContextType ctxType)
        {
            if (_PC == null)
            {
                _Localserver = ConfigurationManager.AppSettings["localserver"];
                _Localroot = ConfigurationManager.AppSettings["localroot"];
                _UserName = ConfigurationManager.AppSettings["username"];
                _Password = ConfigurationManager.AppSettings["password"];
                
                //TODO: Modify this statement
                _PC = new PrincipalContext(ctxType, _Localserver, _Localroot, _UserName, _Password);
            }
            return _PC;
        }

    }
}