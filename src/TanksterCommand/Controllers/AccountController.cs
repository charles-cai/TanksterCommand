namespace TanksterCommand.Controllers
{
    using System;
    using System.Configuration;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using System.Web.Security;

    [Authorize]
    public class AccountController : Controller
    {
        private const string FacebookApiProfileUrl = "https://graph.facebook.com/me";

        private readonly string facebookApiClientId = ConfigurationManager.AppSettings["FacebookAppId"];
        private readonly string facebookApiClientSecret = ConfigurationManager.AppSettings["FacebookAppSecret"];

        [HttpGet]
        [AllowAnonymous]
        public ActionResult FacebookLogin(string code, string state, string returnUrl)
        {
            if (string.IsNullOrEmpty(code))
            {
                // Redirect to Facebook Login
                var redirectUri = this.GetLoginAbsoluteUrl();
                var facebookLoginUrl = "https://graph.facebook.com/oauth/authorize?client_id=" + this.facebookApiClientId + "&scope=&state=" + HttpUtility.UrlEncode(returnUrl) + "&redirect_uri=" + HttpUtility.UrlEncode(redirectUri);
                return this.Redirect(facebookLoginUrl);
            }

            var tokenUrl = string.Format(
                                    CultureInfo.InvariantCulture,
                                    "https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}",
                                    this.facebookApiClientId,
                                    this.GetLoginAbsoluteUrl(),
                                    this.facebookApiClientSecret,
                                    code);

            var accessToken = string.Empty;

            try
            {
                using (var client = new WebClient())
                {
                    var receivedStream = client.OpenRead(tokenUrl);
                    using (var tokenReader = new StreamReader(receivedStream))
                    {
                        accessToken = tokenReader.ReadToEnd();

                        var userProfileUrl = new Uri(string.Format("{0}?{1}", FacebookApiProfileUrl, accessToken));
                        receivedStream = client.OpenRead(userProfileUrl);

                        using (var profileReader = new StreamReader(receivedStream))
                        {
                            receivedStream = client.OpenRead(userProfileUrl);
                            var result = profileReader.ReadToEnd();
                            var userProfile = new JavaScriptSerializer().Deserialize<dynamic>(result);
                            FormsAuthentication.SetAuthCookie(userProfile["name"], createPersistentCookie: true);
                            return Redirect(string.IsNullOrEmpty(state) ? "~/" : HttpUtility.UrlDecode(state));
                        }
                    }
                }
            }
            catch (Exception)
            {
                // TODO: Handle appropiate error.
                return Redirect("~/");
            }
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private string GetLoginAbsoluteUrl()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}://{1}{2}",
                Request.Url.Scheme,
                Request.Url.Authority,
                Url.RouteUrl(new { controller = "Account", Action = "FacebookLogin" }));
        }
    }
}
