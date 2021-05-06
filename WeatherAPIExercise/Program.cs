using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WeatherAPIExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Please enter your API Key:");
            var api_key = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter your city name:");
                var city_name = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_key}";

                var response = client.GetStringAsync(weatherURL).Result;

                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();

                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose another city? yes/no");
                var userContinue = Console.ReadLine();
                if(userContinue.ToLower() == "no")
                {
                    Console.WriteLine("Thank you for using our service.");
                    Environment.Exit(0);
                }
            }


        }
    }
}
