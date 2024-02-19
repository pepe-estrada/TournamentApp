using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Functions.AzureClients;
using TournamentApp.Models;

namespace TournamentApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult ThankYou()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpPost]
    public IActionResult SubmitInformation()
    {
        string conn = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING")!;
        if(String.IsNullOrEmpty(conn)){
            return BadRequest("Connection string is empty");
        }
        LocalSqlClient.SendInformation(conn);
        return Ok();
    }
}
