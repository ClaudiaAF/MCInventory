using System;
using System.Text;
using System.IO;
using HtmlAgilityPack;
using System.Collections;

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

            HtmlNode someNode = htmlDoc.GetElementbyId("TheList");
            Console.WriteLine(someNode.OuterHtml);


            someNode.RemoveAllChildren();
            ArrayList newItems = Inventory.items;

             foreach (Block currentBlock in Inventory.items)
            {
                HtmlNode newNode = HtmlNode.CreateNode(
                	"<div class='row text-center' style='float:left;'><div class='col-sm colm-left'><div class='card text-center' style='width: 18rem; margin-left:30px; margin-bottom:10%; border-styles'><img class='card-img-top mx-auto' text-align='center' style='width: 150px; height: 150px; padding: 15px;'  src=\""+currentBlock.BlockImage+"\"><div class='card-body'><h5 class='card-title'>" + "<label for=\"" + currentBlock.BlockType + "\">"+currentBlock.BlockType+"</label>" + "</h5><div class='input-group mb-3'><input class='form-control' aria-label='Recipients username' aria-describedby='basic-addon2' type=\"number\" id=\""+currentBlock.BlockType+"\" name=\""+currentBlock.BlockType+"\" value=\""+currentBlock.Count+"\"/><div class='ld-over-full'><button class='btn btn-outline-success ld-over-full' type='submit' value='Submit'>Update</button></div></div></div></div></div>");
                someNode.AppendChild(newNode);
                
            }

            someNode = htmlDoc.GetElementbyId("RecipeList");

            foreach(Recipe curRecipe in RecipeBook.Recipes)
            {
                HtmlNode newNode = HtmlNode.CreateNode("<li class='list-group-item'><a href='#' style='border: 0;' class='list-group-item list-group-item-action'><input type=\"submit\" value=\""+ curRecipe.Result.BlockType + "\"/><img src='img/sledgeHammer_Icon.png' class='rounded float-right' style='width:50px; height:50px; margin-top:-49px; margin-right: 12%;'></li></a>");
                someNode.AppendChild(newNode);
            }
            

            return htmlDoc.DocumentNode.InnerHtml;


        
        }

        
    }
}