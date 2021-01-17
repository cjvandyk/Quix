#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Approval.Controllers
{
    [System.Web.Http.Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get(IEnumerable<string> ids)
        {
            string returnValue = "Values: ";
            foreach (string id in ids)
            {
                returnValue += ("{" + id + "}");
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string id)
        {
            if (id == "3")
            {
                Quix.Auth auth = new Quix.Auth(
                System.Configuration.ConfigurationManager.AppSettings["ClientId"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["TenantId"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["TenantUrl"].ToString(),
                System.Configuration.ConfigurationManager.AppSettings["AccessScopes"].ToString().Split(','),
                System.Configuration.ConfigurationManager.AppSettings["TokenFile"].ToString());

                System.Net.Http.HttpClient client = auth.GetHttpClient();
                System.Net.Http.HttpResponseMessage response = client.GetAsync("https://cjvandyk.sharepoint.com/sites/Approval/_api/web/lists/GetByTitle('Approval')/items?$select=Title,ID&$filter=Title%20eq%20%27Test%27").GetAwaiter().GetResult();
                return "value {" + id + "}" + response.ToString();
            }
            return "value {" + (Convert.ToInt16(id) + 27) + "}";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
