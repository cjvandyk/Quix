using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// This project contains code for use in GCC High environments.
/// </summary>
namespace Quix.GCCH
{
    /// <summary>
    /// Static class containing tools for use in GCC High.
    /// </summary>
    public static class Tools
    {
        //Globals
        private static string adminComponent = "admin";
        private static string mySiteComponent = "my";

        /// <summary>
        /// Convert tenant URL to specialty URL.
        /// </summary>
        /// <param name="tenantUrl">The tenant URL.</param>
        /// <param name="conversionComponent">The component such as admin for 
        /// the admin portal or my for mysites.</param>
        /// <returns>The converted tenant URL without https:// header.</returns>
        public static string ConvertTenantUrl(string tenantUrl, 
                                              string conversionComponent)
        {
            //Strip https:// and http:// if in the URL.  Trim trailing slash 
            //  and split by .
            string[] parts = tenantUrl.ToLower()
                                      .Replace("https://", "")
                                      .Replace("http://", "")
                                      .TrimEnd('/')
                                      .Split('.');
            string result = "";
            bool adminAppended = false;
            foreach (string part in parts)
            {
                if (!adminAppended)
                {
                    result = result + part + "-" + conversionComponent + ".";
                    adminAppended = true;
                }
                else
                {
                    result = result + part + ".";
                }
            }
            //Trim trailing period before returning result.
            return result.TrimEnd('.');
        }

        /// <summary>
        /// Convert given tenant URL to admin URL.
        /// </summary>
        /// <param name="tenantUrl">The tenant URL.</param>
        /// <returns>The tenant admin URL without https:// header.</returns>
        public static string GetTenantAdminUrl(string tenantUrl)
        {
            return ConvertTenantUrl(tenantUrl, adminComponent);
        }

        /// <summary>
        /// Convert given tenant URL to MySite URL.
        /// </summary>
        /// <param name="tenantUrl">The tenant URL.</param>
        /// <returns>The tenant MySite URL without https:// header.</returns>
        public static string GetTenantMySiteUrl(string tenantUrl)
        {
            return ConvertTenantUrl(tenantUrl, mySiteComponent);
        }
    }
}
