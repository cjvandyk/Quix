using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quix
{
    public class Auth
    {
        public string[] accessScopes { get; private set; } =
            new string[] {"https://cjvandyk.sharepoint.com/AllSites.FullControl",
                          "offline_access"};
        public string clientId { get; private set; } = 
            "69f31429-3ea7-4160-91dd-6cd9e401ce2a";
        public string tenantId { get; private set; } = 
            "58d4b65b-4cf1-4467-ba8e-f22271da8a3c";
        public string tenantRoot { get; private set; } = 
            "https://cjvandyk.sharepoint.com";
        public string tokenFile { get; private set; }
        public int tokenTimeoutInSeconds { get; private set; }

        private string accessToken = "";
        private DateTime accessTokenCreated;
        private System.Net.Http.HttpClient httpClient =
            new System.Net.Http.HttpClient();
        private Msal msal = new Msal();
        
        public Auth(
            string clientid, 
            string tenantid, 
            string tenantroot, 
            string[] accessscopes, 
            string tokenfile = null)
        {
            if (tokenfile == null)
            {
                tokenfile = @"C:\Tokens\" + System.Environment.UserName + @".token";
            }
            clientId = clientid;
            tenantId = tenantid;
            if (Quix.Core.String.IsUrlRootOnly(tenantroot))
            {
                tenantRoot = tenantroot;
            }
            else
            {
                tenantRoot = Quix.Core.String.GetUrlRoot(tenantroot);
            }
            accessScopes = accessscopes;
            tokenFile = tokenfile;
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(
                    "application/json"));
            RefreshToken();
        }

        private void RefreshToken()
        {
            Microsoft.Identity.Client.AuthenticationResult authResult = 
                msal.GetAuthTokenAsync(clientId,
                                       tenantId,
                                       accessScopes,
                                       tokenFile
                                      ).GetAwaiter()
                                       .GetResult();
            if (authResult != null)
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        authResult.AccessToken);
                accessToken = authResult.AccessToken;
                accessTokenCreated = DateTime.UtcNow;
            }
        }

        public Microsoft.SharePoint.Client.ClientContext GetClientContext(
            string clientid,
            string tenantid,
            string url,
            string[] scopes,
            string tokenfile)
        {
            try
            {
                Microsoft.Identity.Client.AuthenticationResult authResult =
                    msal.GetAuthTokenAsync(clientid,
                                           tenantid,
                                           scopes,
                                           tokenfile
                                          ).GetAwaiter()
                                           .GetResult();
                return GetClientContext(GetValidAccessToken(), url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Microsoft.SharePoint.Client.ClientContext GetClientContext(
            string url)
        {
            return GetClientContext(GetValidAccessToken(), url);
        }

        private Microsoft.SharePoint.Client.ClientContext GetClientContext(
            string accesstoken,
            string url)
        {
            try
            {
                if (string.IsNullOrEmpty(accesstoken) || string.IsNullOrEmpty(url))
                {
                    throw new ArgumentNullException();
                }
                var context = new Microsoft.SharePoint.Client.ClientContext(url);
                context.ExecutingWebRequest += (sender, args) =>
                {
                    args.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + accesstoken;
                };
                return context;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Net.Http.HttpClient GetHttpClient()
        {
            GetValidAccessToken();
            return httpClient;
        }

        public Microsoft.Identity.Client.AuthenticationResult GetNewToken(
            string[] accessscopes)
        {
            return msal.GetAuthTokenAsync(clientId,
                                          tenantId,
                                          accessscopes,
                                          tokenFile
                                         ).GetAwaiter()
                                          .GetResult();
        }

        public string GetValidAccessToken()
        {
            try
            {
                if (TokenTimedOut())
                {
                    RefreshToken();
                }
                return accessToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool TokenTimedOut()
        {
            if (DateTime.UtcNow.Subtract(accessTokenCreated).TotalSeconds > tokenTimeoutInSeconds)
            {
                return true;
            }
            return false;
        }
    }
}
