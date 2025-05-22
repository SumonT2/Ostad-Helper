using System.Diagnostics;
using System.Text.Json;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ostad_Helper.Models;
using Ostad_Helper.Models.Ostad_Helper.Models;
using Ostad_Helper.Utils;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Ostad_Helper.Controllers;

public class HomeController : Controller
{
    private readonly ApiClient _apiClient;
    private readonly ILogger<HomeController> _logger;
    private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(2); // Limit to 10 concurrent requests
    public HomeController(ApiClient apiClient, ILogger<HomeController> logger)
    {
        _apiClient = apiClient;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _apiClient.GetAsync(ApiEndpoints.Batch);

        return View();
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
        var response = await _apiClient.GetAsync(ApiEndpoints.Batch);

        if (response == null)
            return new EmptyResult(); // Already redirected

        var json = await response.Content.ReadAsStringAsync();
        BatchRoot apiData1 = JsonConvert.DeserializeObject<BatchRoot>(json);
        List<BatchResult> batchresult = apiData1.data.results.Where(x=>x.is_on_demand==false).ToList();


        return View(model: batchresult);
    }

  
    public async Task<IActionResult> StudyPlansAsync()
    {

        string id = "67d133268522c9bf0e68705b";
        var response = await _apiClient.GetAsync(ApiEndpoints.StudyPlan(id));

        if (response == null)
            return new EmptyResult();

        var json = await response.Content.ReadAsStringAsync();
        StudyPlanRoot apiData = JsonConvert.DeserializeObject<StudyPlanRoot>(json);
        List<StudyPlan> studyPlan = apiData.data.study_plans.ToList();


        return View(model: studyPlan);
    }




    //public async Task<IActionResult> StudyPlanDetailsAsync()
    //{
    //    List<StudyPlanDetailsTimeline> stdline = new();

    //    // Fetch batch data
    //    var batchResponse = await _apiClient.GetAsync(ApiEndpoints.Batch);
    //    if (batchResponse == null || !batchResponse.IsSuccessStatusCode)
    //    {
    //        System.Diagnostics.Debug.WriteLine($"Batch API failed: {batchResponse?.StatusCode}");
    //        return new EmptyResult();
    //    }

    //    var batchJson = await batchResponse.Content.ReadAsStringAsync();
    //    BatchRoot batchRootData = JsonSerializer.Deserialize<BatchRoot>(batchJson, new JsonSerializerOptions
    //    {
    //        PropertyNameCaseInsensitive = true
    //    });
    //    var batches = batchRootData.data.results.Where(x => !x.is_on_demand).ToList();

    //    // Process batches in parallel with throttling
    //    var batchTasks = batches.Select(async batch =>
    //    {
    //        await _semaphore.WaitAsync();
    //        try
    //        {
    //            var studyPlanResponse = await _apiClient.GetAsync(ApiEndpoints.StudyPlan(batch._id));
    //            if (studyPlanResponse == null || !studyPlanResponse.IsSuccessStatusCode)
    //            {
    //                System.Diagnostics.Debug.WriteLine($"StudyPlan API failed for batch {batch._id}: {studyPlanResponse?.StatusCode}");
    //                return new List<StudyPlanDetailsTimeline>();
    //            }

    //            var studyPlanJson = await studyPlanResponse.Content.ReadAsStringAsync();
    //            StudyPlanRoot stdRoot = JsonSerializer.Deserialize<StudyPlanRoot>(studyPlanJson, new JsonSerializerOptions
    //            {
    //                PropertyNameCaseInsensitive = true
    //            });
    //            var studyPlans = stdRoot.data.study_plans.ToList();

    //            // Fetch study plan details in parallel with throttling
    //            var studyPlanTasks = studyPlans.Select(async studyPlan =>
    //            {
    //                await _semaphore.WaitAsync();
    //                try
    //                {
    //                    var response = await _apiClient.GetAsync(ApiEndpoints.StudyPlanDetails(studyPlan._id));
    //                    if (response == null || !response.IsSuccessStatusCode)
    //                    {
    //                        System.Diagnostics.Debug.WriteLine($"StudyPlanDetails API failed for {studyPlan._id}: {response?.StatusCode}");
    //                        return new List<StudyPlanDetailsTimeline>();
    //                    }

    //                    var json = await response.Content.ReadAsStringAsync();
    //                    StudyPlanDetailsRoot apiData = JsonSerializer.Deserialize<StudyPlanDetailsRoot>(json, new JsonSerializerOptions
    //                    {
    //                        PropertyNameCaseInsensitive = true
    //                    });
    //                    var types = new[] { "quiz", "assignment", "practice_coding_test", "project", "written" };
    //                    return apiData.data.timeline
    //                        .Where(x => types.Contains(x.type))
    //                        .ToList();
    //                }
    //                finally
    //                {
    //                    _semaphore.Release();
    //                }
    //            }).ToList();

    //            return (await Task.WhenAll(studyPlanTasks)).SelectMany(r => r).ToList();
    //        }
    //        finally
    //        {
    //            _semaphore.Release();
    //        }
    //    }).ToList();

    //    // Wait for all batch tasks and combine results
    //    stdline.AddRange((await Task.WhenAll(batchTasks)).SelectMany(r => r));

    //    // Return empty result if no data
    //    if (!stdline.Any())
    //        return new EmptyResult();

    //    // Order by last_submission_date, handling nulls
    //    return View(model: stdline.OrderBy(x => x.last_submission_date ?? DateTimeOffset.MaxValue).ToList());
    //}











    //public async Task<IActionResult> StudyPlanDetailsAsync()
    //{
    //    List<StudyPlanDetailsTimeline> stdline = new();

    //    // Fetch batch data
    //    var batchResponse = await _apiClient.GetAsync(ApiEndpoints.Batch);
    //    if (batchResponse == null)
    //        return new EmptyResult(); // Already redirected

    //    var batchJson = await batchResponse.Content.ReadAsStringAsync();
    //    BatchRoot batchRootData = JsonSerializer.Deserialize<BatchRoot>(batchJson, new JsonSerializerOptions
    //    {
    //        PropertyNameCaseInsensitive = true
    //    });
    //    var batches = batchRootData.data.results.Where(x => !x.is_on_demand).ToList();

    //    // Process batches in parallel
    //    var batchTasks = batches.Select(async batch =>
    //    {
    //        var studyPlanResponse = await _apiClient.GetAsync(ApiEndpoints.StudyPlan(batch._id));
    //        if (studyPlanResponse == null)
    //            return new List<StudyPlanDetailsTimeline>();

    //        var studyPlanJson = await studyPlanResponse.Content.ReadAsStringAsync();
    //        MinimalStudyPlanRoot stdRoot = JsonSerializer.Deserialize<MinimalStudyPlanRoot>(studyPlanJson, new JsonSerializerOptions
    //        {
    //            PropertyNameCaseInsensitive = true
    //        });
    //        var studyPlans = stdRoot.data.study_plans.ToList();

    //        // Fetch study plan details in parallel
    //        var studyPlanTasks = studyPlans.Select(async studyPlan =>
    //        {
    //            var response = await _apiClient.GetAsync(ApiEndpoints.StudyPlanDetails(studyPlan._id));
    //            if (response == null)
    //                return new List<StudyPlanDetailsTimeline>();

    //            var json = await response.Content.ReadAsStringAsync();
    //            StudyPlanDetailsRoot apiData = JsonSerializer.Deserialize<StudyPlanDetailsRoot>(json, new JsonSerializerOptions
    //            {
    //                PropertyNameCaseInsensitive = true
    //            });
    //            return apiData.data.timeline
    //                .Where(x => new[] { "quiz", "assignment", "practice_coding_test", "project", "written" }.Contains(x.type))
    //                .ToList();
    //        }).ToList();

    //        return (await Task.WhenAll(studyPlanTasks)).SelectMany(r => r).ToList();
    //    }).ToList();

    //    // Wait for all batch tasks and combine results
    //    stdline.AddRange((await Task.WhenAll(batchTasks)).SelectMany(r => r));

    //    // Return empty result if no data
    //    if (!stdline.Any())
    //        return new EmptyResult();

    //    // Order by last_submission_date, handling nulls
    //    return View(model: stdline.OrderBy(x => x.last_submission_date ?? DateTimeOffset.MaxValue).ToList());
    //}

    #region
    //public async Task<IActionResult> StudyPlanDetailsAsync()
    //{
    //    List<StudyPlanDetailsTimeline> stdline = new();

    //    var batchResponse = await _apiClient.GetAsync(ApiEndpoints.Batch);

    //    if (batchResponse == null)
    //        return new EmptyResult(); // Already redirected

    //    var batchJson = await batchResponse.Content.ReadAsStringAsync();
    //    BatchRoot batchRootData = JsonConvert.DeserializeObject<BatchRoot>(batchJson);
    //    List<BatchResult> batchresult = batchRootData.data.results.Where(x => x.is_on_demand == false).ToList();


    //    foreach (var batch in batchresult)
    //    {
    //        var studyPlanResponse = await _apiClient.GetAsync(ApiEndpoints.StudyPlan(batch._id));
    //        if (studyPlanResponse == null)
    //            return new EmptyResult();

    //        var studyPlanJson = await studyPlanResponse.Content.ReadAsStringAsync();
    //        MinimalStudyPlanRoot stdRoot = JsonSerializer.Deserialize<MinimalStudyPlanRoot>(studyPlanJson, new JsonSerializerOptions
    //        {
    //            PropertyNameCaseInsensitive = true
    //        });
    //        var studyPlans = stdRoot.data.study_plans.ToList();

    //        // Fetch study plan details in parallel
    //        var tasks = studyPlans.Select(async studyPlan =>
    //        {
    //            var response = await _apiClient.GetAsync(ApiEndpoints.StudyPlanDetails(studyPlan._id));
    //            if (response == null)
    //                return new List<StudyPlanDetailsTimeline>();

    //            var json = await response.Content.ReadAsStringAsync();
    //            StudyPlanDetailsRoot apiData = JsonSerializer.Deserialize<StudyPlanDetailsRoot>(json, new JsonSerializerOptions
    //            {
    //                PropertyNameCaseInsensitive = true
    //            });
    //            return apiData.data.timeline
    //                .Where(x => new[] { "quiz", "assignment", "practice_coding_test", "project", "written" }.Contains(x.type))
    //                .ToList();
    //        }).ToList();
    //        stdline.AddRange((await Task.WhenAll(tasks)).SelectMany(r => r));
    //    }


    //    if (!stdline.Any())
    //        return new EmptyResult();

    //    return View(model: stdline.OrderBy(x => x.last_submission_date).ToList());
    //}
    #endregion

    #region
    //public async Task<IActionResult> StudyPlanDetailsAsync()
    //{
    //    List<StudyPlanDetailsTimeline> stdline = new List<StudyPlanDetailsTimeline>();
    //    var studyplanresponse = await _apiClient.GetAsync(ApiEndpoints.StudyPlan("67d133268522c9bf0e68705b"));
    //    if (studyplanresponse == null)
    //        return new EmptyResult();

    //    var studyplanjson = await studyplanresponse.Content.ReadAsStringAsync();
    //    StudyPlanRoot stdroot = System.Text.Json.JsonSerializer.Deserialize<StudyPlanRoot>(studyplanjson, new JsonSerializerOptions
    //    {
    //        PropertyNameCaseInsensitive = true
    //    });
    //    List<StudyPlan> studyPlans = stdroot.data.study_plans.ToList();

    //    // Create a list of tasks for parallel API calls
    //    var tasks = studyPlans.Select(async studyPlan =>
    //    {
    //        var response = await _apiClient.GetAsync(ApiEndpoints.StudyPlanDetails(studyPlan._id));
    //        if (response == null)
    //            return new List<StudyPlanDetailsTimeline>();

    //        var json = await response.Content.ReadAsStringAsync();
    //        StudyPlanDetailsRoot apiData = JsonConvert.DeserializeObject<StudyPlanDetailsRoot>(json);
    //        return apiData.data.timeline
    //            .Where(x => new[] { "quiz", "assignment", "practice_coding_test", "project", "written" }.Contains(x.type))
    //            .ToList();
    //    }).ToList();

    //    // Wait for all tasks to complete
    //    var results = await Task.WhenAll(tasks);

    //    // Combine all results
    //    stdline.AddRange(results.SelectMany(r => r));

    //    return View(model: stdline);
    //}
    #endregion

    // Study Plan Details with Cache
    public async Task<IActionResult> StudyPlanDetailsAsync()
    {
        var stdline = new List<StudyPlanDetailsTimeline>();
        var cache = await StudyPlanCacheHelper.LoadCacheAsync();

        foreach (var item in cache.Items)
        {
            var tasks = item.StudyPlanIds.Select(async planId =>
            {
                var response = await _apiClient.GetAsync(ApiEndpoints.StudyPlanDetails(planId));
                if (response == null)
                    return new List<StudyPlanDetailsTimeline>();

                var json = await response.Content.ReadAsStringAsync();
                var apiData = JsonSerializer.Deserialize<StudyPlanDetailsRoot>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return apiData?.data?.timeline
                    ?.Where(x => new[] { "quiz", "assignment", "practice_coding_test", "project", "written" }.Contains(x.type))
                    .ToList() ?? new();
            }).ToList();

            stdline.AddRange((await Task.WhenAll(tasks)).SelectMany(x => x));
        }

        if (!stdline.Any())
            return new EmptyResult();

        return View(stdline.OrderBy(x => x.last_submission_date).ToList());
    }

    public async Task<IActionResult> GenerateStudyPlanCache()
    {
        var cache = new CachedStudyPlanList();
        var batchResponse = await _apiClient.GetAsync(ApiEndpoints.Batch);

        if (batchResponse == null)
            return Content("Failed to get batch data");

        var batchJson = await batchResponse.Content.ReadAsStringAsync();
        var batchRoot = JsonConvert.DeserializeObject<BatchRoot>(batchJson);
        var batches = batchRoot.data.results.Where(x => !x.is_on_demand).ToList();

        foreach (var batch in batches)
        {
            var studyPlanResponse = await _apiClient.GetAsync(ApiEndpoints.StudyPlan(batch._id));
            if (studyPlanResponse == null)
                continue;

            var studyPlanJson = await studyPlanResponse.Content.ReadAsStringAsync();
            var stdRoot = JsonSerializer.Deserialize<MinimalStudyPlanRoot>(studyPlanJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var studyPlanIds = stdRoot?.data.study_plans.Select(p => p._id).ToList() ?? new();
            cache.Items.Add(new CachedStudyPlanInfo
            {
                BatchId = batch._id,
                StudyPlanIds = studyPlanIds
            });
        }

        await StudyPlanCacheHelper.SaveCacheAsync(cache);
        return Content("Cache saved successfully");
    }


}
