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
        /// <summary>
        /// Convert given tenant URL to admin URL.
        /// </summary>
        /// <param name="tenantUrl">The tenant URL.</param>
        /// <returns>The tenant admin URL without https:// header.</returns>
        public static string GetTenantAdminUrl(string tenantUrl)
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
                    result = result + part + "-admin.";
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
    }
}
