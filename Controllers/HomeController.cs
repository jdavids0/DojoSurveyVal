using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyVal.Models;

namespace DojoSurveyVal.Controllers;

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

    [HttpPost("submit")]
    public IActionResult Submit(Survey survey)
    {
        if(ModelState.IsValid){
            return RedirectToAction ("Success", survey);
        }
        else 
        {
            return View("Index");
        }
    }

    [HttpGet("success")]
    public IActionResult Success(Survey survey)
    {
        // ViewBag.Survey = newSurvey;
        return View("Success", survey);
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
