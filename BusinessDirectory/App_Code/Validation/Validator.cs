using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace GoProGo.Validation
{
    /// <summary>
    /// Summary description for Validations
    /// </summary>
    public static class Validator
    {
        public static bool ValidateEmailAddress(string email)
        {
            //Matches e-mail addresses, including some of the newer top-level-domain extensions, such as info, museum, name, etc. Also allows for emails tied directly to IP addresses. 
            //Matches example@example.com | foo@bar.info | blah@127.0.0.1 
            //Non-Matches broken@@example.com | foo@bar.infp | blah@.nospam.biz 

            Regex emailExp = new Regex(@"^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name))$");
            return emailExp.IsMatch(email);
        }

        public static bool ValidateStrings(string strOne, string strTwo)
        {
            return strOne.Equals(strTwo);
        }
    }
}
