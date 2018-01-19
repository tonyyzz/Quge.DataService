using System;
using System.IO;
using System.Net;

namespace System
{
    public  class ResponseHelper
    {
        #region post请求
        public static string GetContent(string url, string paramStrs)
        {
            Uri uri = new Uri(url);
            try
            {
                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                request.Method = "post";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Access-Control-Allow-Origin:*");
                string reqdata = paramStrs;
                byte[] buf = System.Text.Encoding.UTF8.GetBytes(reqdata);
                System.IO.Stream s = request.GetRequestStream();
                s.Write(buf, 0, buf.Length);
                s.Close();
                HttpWebResponse res = request.GetResponse() as HttpWebResponse;
                StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8);
                string html = sr.ReadToEnd();
                return html;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        #endregion
    }
}
