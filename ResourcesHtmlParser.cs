using System;
using System.Text;
using System.IO;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace MCInventory
{
    class ResourcesHtmlParser
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

            HtmlNode itemNode = htmlDoc.GetElementbyId("itemContainer");
            Console.WriteLine(itemNode.OuterHtml);

            string[] resourceNames = {"birch", "birch", "birch", "birch", "birch", "birch", "birch", "birch", "birch", "birch", "birch"};

            foreach (string resTitle in resourceNames)
            {
                HtmlNode newNode = HtmlNode.CreateNode("<div class='row text-center'><div class='col-sm colm-left'><p value='resource-label' class='resource-label'>Resource Name</p><img src='img/tree-resource.jpg' class='resource-img'/><p value='integer' class='resource-amount' >5</p></div><div class='col-sm colm-middle'><p value='resource-label' class='resource-label'>" + resTitle + "</p><img src='img/tree-resource.jpg' class='resource-img'/><p value='integer' class='resource-amount'>5</p></div><div class='col-sm colm-right'><p value='resource-label' class='resource-label'>Resource Name</p><img src='img/tree-resource.jpg' class='resource-img'/><p value='integer' class='resource-amount'>5</p></div></div>");
                itemNode.AppendChild(newNode);
            }
            

            return htmlDoc.DocumentNode.InnerHtml;


        
        }

        
    }
}