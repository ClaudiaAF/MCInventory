using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace MCInventory
{
    class Program
    {
        public static HttpListener listener;
        public static string url = "http://localhost:8000/";
        public static int pageViews = 0;
        public static int requestCount = 0;
        public static string pageData = 
        "<!DOCTYPE>" + 
        "<html>" +
            "<head>" +
                "<title>HTTP listener example</title>" +
                "</head>" + 
                "</body>" +
                    "<p>Page Views: {0}</p>" +
                    "<form method=\"post\" action=\"shutdown\">" + 
                        "<input type=\"submit\" value=\"Shutdown\" {1}>" +
                    "</form>" +
                "</body>" +
            "</html>";

        public static async Task HandleIncommingConnections()
        {
            bool runServer = true;
            //as long as shutdown hasn't been selected, keep on handling requests
            while (runServer)
            {
                //wait here till we hear from connection
                HttpListenerContext ctx = await listener.GetContextAsync();
                //peel out the request and the response
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse res = ctx.Response;
                //print out info regarding the request
                Console.WriteLine("Request #: {0}", ++requestCount);
                Console.WriteLine(req.Url.ToString());
                Console.WriteLine(req.HttpMethod);
                Console.WriteLine(req.UserHostName);
                Console.WriteLine(req.UserAgent);
                Console.WriteLine();

                //if 'shutdown' requested with POST, the shutdown server after leaving page
                if ((req.HttpMethod == "POST") && (req.Url.AbsolutePath == "/shutdown"))
                {
                    Console.WriteLine("Shutdown requested");
                    runServer = false;
                }
                //ensure we don't increment the page views if favicon shows 
                if (req.Url.AbsolutePath != "/favicon.ico")
                pageViews+= 1;

                string disableSubmit = !runServer ? "disabled" : "";
                byte[] data = Encoding.UTF8.GetBytes(String.Format(pageData, pageViews, disableSubmit));
                res.ContentType = "text/html";
                res.ContentEncoding = Encoding.UTF8;
                res.ContentLength64 = data.LongLength;
                //write to the response stream, and then close it
                await res.OutputStream.WriteAsync(data, 0, data.Length);
                //close the listener
                res.Close();
            }
        }
        static void Main(string[] args)
        {
            listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
        
            Console.WriteLine("Listening for connections on" + url);

            Task listenTask = HandleIncommingConnections();
            listenTask.GetAwaiter().GetResult();

            listener.Close();
        }
    }
}
