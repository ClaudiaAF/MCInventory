using System;
using System.Text;
using System.IO;
using HtmlAgilityPack;

namespace MCInventory
{
    class RecipesHtmlParser
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

            HtmlNode itemNode = htmlDoc.GetElementbyId("recipe-container");
            Console.WriteLine(itemNode.OuterHtml);

            string[] recipeNames = {"birch", "oak", "coal", "sand", "bucket", "fishing rod", "lapus-lazuli", "cobblestone", "wooden pick-axe", "arrow", "bones"};

            foreach (string recTitle in recipeNames)
            {
                HtmlNode newNode = HtmlNode.CreateNode("<div class='row text-center' style='margin-top: 3%;'><div class='col-sm colm-left'><p value='recipe-label' class='recipe-label'>" + recTitle + "</p><img src='img/recipe-grid.jpg' class='recipe-grid-img'/></div><div class='col-sm colm-middle'><p value='recipe-label' class='recipe-label'>" + recTitle + "</p><img src='img/recipe-grid.jpg' class='recipe-grid-img'/></div><div class='col-sm colm-right'><p value='recipe-label' class='recipe-label'>Recipe Name</p><img src='img/recipe-grid.jpg' class='recipe-grid-img'/></div></div>");
                itemNode.AppendChild(newNode);
            }
            


            return htmlDoc.DocumentNode.InnerHtml;


        
        }

        
    }
}