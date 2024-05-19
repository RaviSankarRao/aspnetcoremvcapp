using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspnetcoremvcapp.Models;
using System.Web.Http;
using System.Text.Encodings.Web;
using aspnetcoremvcapp.Patterns;

namespace aspnetcoremvcapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index([FromUri] string customcookie)
    {
        SetViewData();
        SetViewBag();
        SetTempData();

        TestLiskovPrincple();

        return View();
    }

    private void TestLiskovPrincple()
    {
        var standardUser = new StandardSubscriber();
        var premiumUser = new PremiumSubscriber();
    }

    private void TestLiskovPrincpleTest(IUserSubscriber subsc)
    {
    }

    public IActionResult Privacy()
    {
        SetTempData();

        return RedirectToAction("PrivacyInternal");
    }

    public IActionResult PrivacyInternal()
    {
        var checkTempData = TempData["Names"];
        
        return View();
    }

    #region Working with parameters

    public string Welcome(string name, int number)
    {
        return HtmlEncoder.Default.Encode($"name is: {name}, number is {number}");
    }

    public string Welcome2(string name, int id = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, ID: {id}");
    }

    #endregion

    #region Passing data to views

    private void SetViewData()
    {
        // Key value pair dictionary
        ViewData["Name"] = "Ravi";
        ViewData["DOB"] = new DateOnly();
    }

    private void SetViewBag()
    {
        List<string> names = new List<string> { "John", "Snow", "Peter", "Bruce", "Parker" };

        // Dynamic property
        ViewBag.Names = names;
    }

    private void SetTempData()
    {
        List<string> names = new List<string> { "John TD", "Snow TD", "Peter TD", "Bruce TD", "Parker TD" };

        TempData["Names"] = names;
    }

    #endregion


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private void AppendCookie(string key, string value)
    {
        CookieOptions options = new CookieOptions();
        options.Expires = DateTime.Now.AddMinutes(1);
        

        Response.Cookies.Append(key, value, options);

        var cookies = Request.Cookies;
        var cookieValue = cookies[""];
    }
}
