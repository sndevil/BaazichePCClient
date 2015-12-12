using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using Newtonsoft.Json.Linq;


namespace Baaziche
{
    public static class WebHandler
    {

        public static string SignUp(string Username, string Password)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://baaziche.orgfree.com/config.php");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
               // JsonTextWriter writer = new JsonTextWriter(TextWriter.Null);                
               // token.Serialize(writer, tosend);
                JToken token = JToken.Parse("{\"username\":\"value\",\"passhash\":\"value\"}");

                token["username"] = Username;
                token["passhash"] = HashMaker(Password);

                
                string output = token.ToString();
                streamWriter.Write(output);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                return result;
            }
        }

        public static string HashMaker(string Password)
        {
            return Password;
        }
    }
}
