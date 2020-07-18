using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using Xero.Api.Example.Applications.Public;
using Xero.Api.Example.MVC.Helpers;
using Xero.Api.Infrastructure.OAuth;


namespace XeroDemo.Controllers
{
    public class AuthorizationController : Controller
    {
        private string clientId = "";
        private string clientSecret = "";

        public ActionResult Index()
        {
            var xeroAuthorizeUri = new RequestUrl("https://login.xero.com/identity/connect/authorize");
            var url = xeroAuthorizeUri.CreateAuthorizeUrl(
             clientId: clientId,
             responseType: "code", //hardcoded authorisation code for now.
             redirectUri: "https://developer.xero.com",
             state: "your state",
             scope: "openid profile email files accounting.transactions accounting.transactions.read accounting.reports.read accounting.journals.read accounting.settings accounting.settings.read accounting.contacts accounting.contacts.read accounting.attachments accounting.attachments.read offline_access"
         );
            return View();
        }
    }
}