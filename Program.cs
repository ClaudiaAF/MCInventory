using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Collections;

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
                Console.WriteLine("Has entity body: "+ req.HasEntityBody);
                Console.WriteLine();

                if (req.HasEntityBody)
                {
                    System.IO.Stream body = req.InputStream;
                    System.Text.Encoding encoding = req.ContentEncoding;
                    System.IO.StreamReader reader = new System.IO.StreamReader(body,encoding);
                    if (req.ContentType != null)
                        Console.WriteLine("Client data content type: "+req.ContentType);
                    Console.WriteLine("Client data content length: "+req.ContentLength64);
                    
                    Console.WriteLine("Start of data:");
                    string data = reader.ReadToEnd();
                    Console.WriteLine(data);
                    Console.WriteLine("End of data:");
                    body.Close();
                    reader.Close();

                     string[] properties = data.Split('&');
                    foreach (string curProp in properties)
                    {
                        string[] pair = curProp.Split('=');
                        string key = pair[0].Replace('+',' ');
                        if (key == "recipe")
                        {
                            RecipeBook.ApplyRecipe(pair[1].Replace('+',' '));
                        }    

                        else if (Inventory.GetClass(key) != null)
                        {
                            int value = Int32.Parse(pair[1]);
                            Inventory.GetClass(key).Count = value;
                        }     
                    }  

                }


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
                    pageViews += 1;

                try
                {
                    FileLoader myFileLoader = new FileLoader(path);
                    myFileLoader.ReadFile();

                    string disableSubmit = !runServer ? "disabled" : "";
                    byte[] data;

                    if (myFileLoader.mimeType.IndexOf("html") >= 0)
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
            Inventory inventory = new Inventory();
            RecipeBook.Populate();
            foreach (Recipe curRecipe in RecipeBook.Recipes)
            {
                Console.WriteLine("recipe is " + curRecipe.Result.BlockType);
            }

            Block axeBlock = Inventory.GetClass("WoodAxe tool");
            Block woodBlock = Inventory.GetClass("Wood block");
            Block bowBlock = Inventory.GetClass("Bow tool");
            Block stickBlock = Inventory.GetClass("Stick material");
            Block stringBlock = Inventory.GetClass("String material");

            if (woodBlock != null && axeBlock != null && stickBlock != null)
            {
                Recipe axeRecipe = new Recipe((Crafted)axeBlock, new Block[3, 3]
                                {
                                    {woodBlock, woodBlock, null},
                                    {woodBlock, stickBlock, null},
                                    {null,stickBlock,null}
                                });
                                
                RecipeBook.AddRecipe(axeRecipe);
            }

            if (stringBlock != null && stickBlock != null && bowBlock != null)
            {
                Recipe bowRecipe = new Recipe((Crafted)bowBlock, new Block[3, 3]
                                {
                                    {stringBlock, stickBlock, null},
                                    {stringBlock, null, stickBlock},
                                    {stringBlock,stickBlock,null}
                                });
                                
                RecipeBook.AddRecipe(bowRecipe);
            }


            Console.WriteLine("Wood block count is "+Inventory.GetClass("Wood block").Count);
            Inventory.GetClass("Wood block").Count++;
            Console.WriteLine("Wood block count is "+Inventory.GetClass("Wood block").Count);

            foreach (Recipe curRecipe in RecipeBook.Recipes)
            {
                Console.WriteLine("recipe is " + curRecipe.Result.BlockType);
            }

            Console.WriteLine("server version" + Database.GetVersion());

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
