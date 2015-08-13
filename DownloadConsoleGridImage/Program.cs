using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DownloadConsoleGridImage
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = @"http://consolegrid.com/api";
            var console = "Genesis";
            var game = "Teenage Mutant Ninja Turtles - Hyperstone Heist";

            var client = new RestClient(host);
            var request = new RestRequest("top_picture?console={console}&game={game}", Method.POST);
            request.AddUrlSegment("console", console);
            request.AddUrlSegment("game", game);

            var response = client.Execute(request);

            var imageName = string.Format("{0}.png", game);
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(response.Content, imageName);
            }
        }
    }
}
