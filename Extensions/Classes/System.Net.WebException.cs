using System;

namespace Extensions
{
    public static class WebException
    {
        public static System.Net.HttpWebResponse Retry(
            this System.Net.WebException ex,
            System.Net.HttpWebRequest request)
        {
            //Check if the response header contains a Retry-After value.
            if (!string.IsNullOrEmpty(ex.Response.Headers["Retry-After"]))
            {
                bool executeOK = false;
                string accept = request.Accept;
                string method = request.Method;
                while (!executeOK)
                {
                    System.Threading.Thread.Sleep((
                        Convert.ToInt32(
                            ex.Response.Headers["Retry-After"]) + 60) * 1000);
                    //We add 60 seconds to the wait time for good measure.
                    request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(
                        ex.Response.ResponseUri.ToString()
                                               .TrimStart('{')
                                               .TrimEnd('}'));
                    request.Method = method;
                    request.Accept = accept;
                    System.Net.WebHeaderCollection headers;
                    System.Net.WebResponse response;
                    try
                    {
                        response = request.GetResponse();
                        executeOK = true;
                        return response as System.Net.HttpWebResponse;
                    }
                    catch (System.Net.WebException ex2)
                    {
                        return ex2.Retry(request);
                    }
                }
            }
            throw ex;  //There is no Retry-After header so just rethrow.
        }
    }
}
