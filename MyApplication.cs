using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // init with your API key
            var newsApiClient = new NewsApiClient("94ba4129b2154f739c8769d603519ac9");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Apple",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(2022, 9, 19)
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);
                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {
                    // author
                    Console.WriteLine(article.Author);
                    // title
                    Console.WriteLine(article.Title);                    
                    // description
                    Console.WriteLine(article.Description);                    
                }
            }
            Console.ReadLine();
        }
    }
}