using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Xero.Api.Example.Applications.Public;
using Xero.Api.Infrastructure.OAuth;
using XeroDemo.Helpers;

namespace XeroDemo.Controllers
{
    public class HomeController : Controller
    {

        private IMvcAuthenticator _authenticator;
        private ApiUser _user;
        public HomeController()
        {
            _user = XeroApiHelper.User();
            _authenticator = XeroApiHelper.MvcAuthenticator();
        }


        public ActionResult Connect()
        {
            StringBuilder login = new StringBuilder();
            login.Append("https://login.xero.com/identity/connect/authorize");
            login.Append("?response_type=code");
            login.Append("&client_id=" + Common.Helper.ClientId);
            login.Append("&redirect_uri=" + Common.Helper.re_directURI);
            login.Append("&scope=openid profile email accounting.transactions");
            login.Append("&state=123");
            login.Append("&code_challenge=XXXXXXXXX");
            login.Append("&code_challenge_method=S256");

            _user.Name = login.ToString();
            _user.Name = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjFDQUY4RTY2NzcyRDZEQzAyOEQ2NzI2RkQwMjYxNTgxNTcwRUZDMTkiLCJ0eXAiOiJKV1QiLCJ4NXQiOiJISy1PWm5jdGJjQW8xbkp2MENZVmdWY09fQmsifQ.eyJuYmYiOjE1OTUxNDU2NDYsImV4cCI6MTU5NTE0NzQ0NiwiaXNzIjoiaHR0cHM6Ly9pZGVudGl0eS54ZXJvLmNvbSIsImF1ZCI6Imh0dHBzOi8vaWRlbnRpdHkueGVyby5jb20vcmVzb3VyY2VzIiwiY2xpZW50X2lkIjoiMjg4NEFBNjQ5QTA4NEQxNEI4RjBGNDA5NkVFRDY2QkQiLCJzdWIiOiJjYmQ4MWJiY2Y0Zjc1YjFlODlmMWI4NDY0OGY0MjRlMSIsImF1dGhfdGltZSI6MTU5NTE0NTYwOCwieGVyb191c2VyaWQiOiJjYWVmMzQ0Zi02MTk2LTQ5YzgtYTE3NS05Njc3ZDMyMDJhNzQiLCJnbG9iYWxfc2Vzc2lvbl9pZCI6IjNmNzE3ZWE1MjBiMzQxZTM5ZmY4ZmVhMmU1ZjRiNDMwIiwianRpIjoiNmFmMzNmMjUzMmMzYzZjYTUyNTQ4NGM3NDY0NDkxNmEiLCJhdXRoZW50aWNhdGlvbl9ldmVudF9pZCI6IjM4NjlkZWY4LWYwYmMtNDA2NC1hZGM2LTNjZDQwMDUwN2MzOSIsInNjb3BlIjpbImVtYWlsIiwicHJvZmlsZSIsIm9wZW5pZCIsImFjY291bnRpbmcudHJhbnNhY3Rpb25zIiwib2ZmbGluZV9hY2Nlc3MiXX0.WOFUbEfSXXfAIqWREPgBnDlueRkL2JKn8G3ySbfhIDIYL2JWI0Y59Xswa433hYdbGXRYxBLlxkYvG1TZ3CS2Pxy1Ddd_D8aHXQ9xtPL5uR1GyuRe1GH67dTv6hA2tu-ft84uVbMgJyXYVxq9RwRuOgFHRfiptF2HWL8cILjR9NEYjLLBzB36VGIwRjqPn3FCw3c0YcezITza-EEmULZxlIlaOwUsMRJpwsT5rNVtmOdOwIYvoJOm53lp8emnu5GD_35XxegJgZOVH92k2oEHMZyGfwzOzx2EGDwsm2M0DplT_DBNlmDUZe8XCTc6c-Lb3jkTQ_zni_qD3Xu06qX0Gw";
            var authorizeUrl = _authenticator.GetRequestTokenAuthorizeUrl(_user.Name);
            return Redirect(authorizeUrl);
        }

        public ActionResult Authorize(string oauth_token, string oauth_verifier, string org)
        {
            var accessToken = _authenticator.RetrieveAndStoreAccessToken(_user.Name, oauth_token, oauth_verifier, org);
            if (accessToken == null)
                return View("NoAuthorized");

            return View(accessToken);
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------------------
