﻿using System.Diagnostics;
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
        SubmitInformation();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult SubmitInformation()
    {
        string conn = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING")!;
        if(String.IsNullOrEmpty(conn)){
            _logger.LogInformation("Connection string is empty");
            return BadRequest("Connection string is empty");
        }
        try
        {
            LocalSqlClient.SendInformation(conn);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error submitting information");
            return BadRequest("Error submitting information");
        }
        return Ok();
    }
}
