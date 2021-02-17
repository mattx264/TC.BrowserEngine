using System;
using System.Collections.Generic;
using System.Text;

namespace TC.BrowserEngine.Helpers
{
    public static class ConfigHelper
    {
        
        public static string GetServerAddress()
    {
#if DEBUG
return "http://localhost/TC.WebService/";
#else
     return "prod url";
#endif

        }
    }
}
