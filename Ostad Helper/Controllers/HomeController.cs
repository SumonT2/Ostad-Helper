using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ostad_Helper.Models;
using Ostad_Helper.Utils;

namespace Ostad_Helper.Controllers;

public class HomeController : Controller
{
    private readonly ApiClient _apiClient;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ApiClient apiClient, ILogger<HomeController> logger)
    {
        _apiClient = apiClient;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _apiClient.GetAsync("https://api.ostad.app/api/v2/batch");

        if (response == null)
            return new EmptyResult(); // Already redirected

        var json = await response.Content.ReadAsStringAsync();
        // Deserialize if needed and pass to view

        return View(model: json);
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
    public async Task<IActionResult> CoursesAsync()
    {
        var response = await _apiClient.GetAsync("https://api.ostad.app/api/v2/batch");

        if (response == null)
            return new EmptyResult(); // Already redirected

        var json = await response.Content.ReadAsStringAsync();
        BatchRoot apiData1 = JsonConvert.DeserializeObject<BatchRoot>(json);
        List<BatchResult> batchresult = apiData1.data.results.Where(x=>x.is_on_demand==false).ToList();


        return View(model: batchresult);
    }
}
