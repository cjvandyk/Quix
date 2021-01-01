using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quix
{
    public class Msal
    {
        protected Microsoft.Identity.Client.IPublicClientApplication app { get; private set; }
        private readonly object fileLock = new object();
        public string tokenFilePath { get; private set; } = @"C:\Tokens\ApprovalApp.token";

        public async Task<Microsoft.Identity.Client.AuthenticationResult> GetAuthTokenAsync(
            string clientid,
            string tenantid,
            string[] scopes,
            string tokenfile,
            bool govcloud = false)
        {
            app = govcloud ? Microsoft.Identity.Client.PublicClientApplicationBuilder.Create(clientid)
                                                                                      .WithAuthority(
                                                                                          Microsoft.Identity.Client.AzureCloudInstance.AzureUsGovernment,
                                                                                          tenantid)
                                                                                      .Build()
                            : Microsoft.Identity.Client.PublicClientApplicationBuilder.Create(clientid)
                                                                                      .WithTenantId(tenantid)
                                                                                      .Build();
            SetSerialization(
                app.UserTokenCache,
                tokenfile);
            Microsoft.Identity.Client.AuthenticationResult result = await GetAuthTokenAsync(scopes);
            if ((result == null) && (govcloud))
            {
                app = Microsoft.Identity.Client.PublicClientApplicationBuilder.Create(clientid)
                                                                              .WithTenantId(tenantid)
                                                                              .Build();
                SetSerialization(
                    app.UserTokenCache,
                    tokenfile);
                result = await GetAuthTokenAsync(scopes);
            }
            return result;
        }

        private async Task<Microsoft.Identity.Client.AuthenticationResult> GetAuthTokenAsync(
            IEnumerable<string> scopes)
        {
            Microsoft.Identity.Client.AuthenticationResult result = null;
            var accounts = await app.GetAccountsAsync();
            if (accounts.Any())
            {
                try
                {
                    result = await app.AcquireTokenSilent(
                        scopes,
                        accounts.FirstOrDefault()
                        ).ExecuteAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (result == null)
            {
                try
                {
                    result = await app.AcquireTokenWithDeviceCode(
                        scopes,
                        deviceCodeResultCallback =>
                        {
                            Console.WriteLine(deviceCodeResultCallback.Message);
                            return Task.FromResult(0);
                        }).ExecuteAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        private void SetSerialization(
            Microsoft.Identity.Client.ITokenCache tokenCache,
            string tokenFile)
        {
            tokenFilePath = tokenFile;
            tokenCache.SetBeforeAccess(BeforeAccessHandler);
            tokenCache.SetAfterAccess(AfterAccessHandler);
        }

        private void BeforeAccessHandler(
            Microsoft.Identity.Client.TokenCacheNotificationArgs args)
        {
            lock (fileLock)
            {
                try
                {
                    args.TokenCache.DeserializeMsalV3(
                        System.IO.File.Exists(tokenFilePath)
                        ? System.Security.Cryptography.ProtectedData.Unprotect(
                            System.IO.File.ReadAllBytes(tokenFilePath),
                            null,
                            System.Security.Cryptography.DataProtectionScope.CurrentUser)
                        : null);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void AfterAccessHandler(
            Microsoft.Identity.Client.TokenCacheNotificationArgs args)
        {
            if (args.HasStateChanged)
            {
                lock (fileLock)
                {
                    if (System.IO.File.Exists(tokenFilePath))
                    {
                        System.IO.File.WriteAllBytes(
                            tokenFilePath,
                            System.Security.Cryptography.ProtectedData.Protect(
                                args.TokenCache.SerializeMsalV3(),
                                null,
                                System.Security.Cryptography.DataProtectionScope.CurrentUser));
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(
                            System.IO.Path.GetDirectoryName(
                                tokenFilePath)))
                        {
                            System.IO.Directory.CreateDirectory(
                                System.IO.Path.GetDirectoryName(
                                    tokenFilePath));
                        }
                        System.IO.File.WriteAllBytes(
                            tokenFilePath,
                            System.Security.Cryptography.ProtectedData.Protect(
                                args.TokenCache.SerializeMsalV3(),
                                null,
                                System.Security.Cryptography.DataProtectionScope.CurrentUser));
                    }
                }
            }
        }
    }
}
