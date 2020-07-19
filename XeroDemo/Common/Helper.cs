using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace XeroDemo.Common
{
    public static class Helper
    {
        internal static string baseApiUrl = "https://api.xero.com";

        public static string GetStarted = "/connections";
        public const string LoginName = "mr.ankitsahai@gmail.com";
        public const string Password = "15July@20";
        public const string Authority = "https://identity.xero.com";
        public static string CallBackUrl = "https://developer.xero.com";
        //consumerKey
        public const string ClientId = "2884AA649A084D14B8F0F4096EED66BD";
        public const string client_secret = "vF4_1TRym7QIr87wojx5iN_PifeFM16WGQwQ0mgROH-O_bou";
        public const string re_directURI = "https://developer.xero.com";
        public const string scopes = "offline_access openid profile email accounting.transactions";
        public const string state = "123";
        public const string scopers = "offline_access openid profile email accounting.transactions";

        public static string refresh_token = string.Empty;
        public static string access_token = string.Empty;
        public static string xero_tenant_id = string.Empty;

        public static string GlobalCompany = string.Empty;
        public static string AccessToken = string.Empty;
        public static string IdToken = string.Empty;
        public static string RefreshToken = string.Empty;

        // -----------------
        public static string ZeroRequestUrl = "https://api.xero.com/";

    }
}