using System;
using System.Text;
using System.IO;
using HtmlAgilityPack;
using System.Collections;

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

            HtmlNode someNode = htmlDoc.GetElementbyId("TheList");
            Console.WriteLine(someNode.OuterHtml);


            someNode.RemoveAllChildren();
            ArrayList newItems = Inventory.items;

            


            foreach (Block currentBlock in Inventory.items)
            {
                HtmlNode newNode = HtmlNode.CreateNode(
                	"<li><label for=\"" + currentBlock.BlockType + "\">"+currentBlock.BlockType+"</label>" + 
                	"<input type=\"text\" id=\""+currentBlock.BlockType+"\" name=\""+currentBlock.BlockType+
                	"\" value=\""+currentBlock.Count+"\"/></li>");
                someNode.AppendChild(newNode);
            }

            someNode = htmlDoc.GetElementbyId("RecipeList");

            foreach(Recipe curRecipe in RecipeBook.Recipes)
            {
                HtmlNode newNode = HtmlNode.CreateNode("<li><input type=\"submit\" value=\""+ 
                         curRecipe.Result.BlockType + "\"/></li>");
                someNode.AppendChild(newNode);
            }

            


            return htmlDoc.DocumentNode.InnerHtml;


        
        }


        
        }

        
    
}