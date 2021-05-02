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

                string path = req.Url.AbsolutePath;

                //if 'shutdown' requested with POST, the shutdown server after leaving page
                if ((req.HttpMethod == "POST") && (path == "/shutdown"))
                {
                    path = "/index.html";
                    Console.WriteLine("Shutdown requested");
                    runServer = false;
                }
                //ensure we don't increment the page views if favicon shows 
                if (path != "/favicon.ico")
                pageViews+= 1;

                try
                {
                    FileLoader myFileLoader = new FileLoader(path);
                    myFileLoader.ReadFile();

                    string disableSubmit = !runServer ? "disabled" : "";
                    byte[] data;

                    if(myFileLoader.mimeType.IndexOf("html") >= 0)
                    {
                        string input = Encoding.UTF8.GetString(myFileLoader.data);
            
                         if (path == "/resources.html")
                        data = Encoding.UTF8.GetBytes(ResourcesHtmlParser.Process(input));

                        else if (path == "/index.html")
                        data = Encoding.UTF8.GetBytes(IndexHtmlPasrser.Process(input));

                        else if (path == "/recipes.html")
                        data = Encoding.UTF8.GetBytes(RecipesHtmlParser.Process(input));
                    
                    else 
                    
                        throw new FileNotFoundException("non page");
                    }
                            
                    
                    else
                    {
                        data = myFileLoader.data;
                    }
                
                    res.ContentType = myFileLoader.mimeType;
                    res.ContentEncoding = Encoding.UTF8;
                    res.ContentLength64 = data.LongLength;
                    //write to the response stream, and then close it
                    await res.OutputStream.WriteAsync(data, 0, data.Length);
                    //close the listener
                }
                catch (FileNotFoundException e)
                {
                    byte[] data;
                    data = Encoding.UTF8.GetBytes("<h2>A 404 Error has Occured</h2>");
                   
                    res.ContentType = "text/html";
                    res.ContentEncoding = Encoding.UTF8;
                    res.ContentLength64 = data.LongLength;
                    res.StatusCode = 404;

                    await res.OutputStream.WriteAsync(data, 0, data.Length);
                }
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
