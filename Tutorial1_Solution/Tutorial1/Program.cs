using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorial1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length == 0) 
            {
                throw new ArgumentNullException("Need to pass an argument");
            }
            if (args[0] == null)
            {
                throw new ArgumentException("No website url argument");
            }

            var websiteUrl = args[0];
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(websiteUrl);
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                if (matches.Count == 0)
                {
                    Console.WriteLine("No email addresses found");
                }

                foreach (var emailAddress in matches)
                {
                    Console.WriteLine(emailAddress.ToString());
                }
            }
            else
            {
                Console.WriteLine("Error while downloading the page");
            }
            Console.ReadKey();
        }

        //need to implement unique only email addresses
        //need to implement dispose
    }
}
