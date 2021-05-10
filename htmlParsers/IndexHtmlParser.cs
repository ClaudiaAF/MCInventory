using System;
using System.Text;
using System.IO;
using HtmlAgilityPack;

namespace MCInventory
{
    class IndexHtmlPasrser
    {
        public static string Process(string input)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(input);

            if (htmlDoc.ParseErrors != null || htmlDoc.DocumentNode == null)
            {
                int count = 0;
                foreach(var htmlParseError in htmlDoc.ParseErrors)
                {
                    count ++;
                    Console.WriteLine("Parse error: " + htmlParseError.Reason);
                }

                if (count > 0)
                    throw new FileNotFoundException("corrupt file");
            }

            return htmlDoc.DocumentNode.InnerHtml;


        
        }

        
    }
}