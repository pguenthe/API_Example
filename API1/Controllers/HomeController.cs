using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using API1.Models;

namespace API1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //asynchronous controller actions return tasks
        //the task provides in this case the IAction Result (the view)
        //when everything's done
        public async Task<IActionResult> Index()
        {
            //0a. Make Model class(es) for your API response content
            //0b. Use Nuget to install the package Microsoft.AspNet.WebAPI.Client

            //1. create an HttpClient and set it up with the base URL
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.icndb.com");

            //2. Get the result
            var response = await client.GetAsync("jokes/random?exclude=[explicit]");

            //give me the content for debugging purposes
            //ViewData["ResponseCode"] = response.StatusCode;
            //ViewData["APIresponse"] = await response.Content.ReadAsStringAsync();

            //3. Parse the JSON into a typed object--this is creating a Joke
            //   with a JokeContent
            var joke = await response.Content.ReadAsAsync<Joke>();

            return View(joke);
        }

        public async Task<IActionResult> ListJokes()
        {
            //1. Make the HttpClient
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.icndb.com");

            //2. Make the API call and put the result in a variable
            var response = await client.GetAsync("jokes/random/10?limitTo=[nerdy]");

            //3. Parse the response contents as your typed object
            //in this case, it contains an array of JokeContent objects inside the Value
            var jokes = await response.Content.ReadAsAsync<JokeList>();

            return View(jokes);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
