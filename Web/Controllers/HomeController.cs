using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Models; 
using NTierTodoApp.Business;
namespace Web.Controllers;


public class HomeController : Controller
{
    private readonly TaskService _taskService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(TaskService taskService, ILogger<HomeController> logger)
    {
        _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public IActionResult Index()
    {
        var tasks = _taskService.GetTasks();
        return View(tasks);
    }

    [HttpPost]
    public IActionResult AddTask(string title)
    {
        if (!string.IsNullOrWhiteSpace(title))
            _taskService.AddTask(title);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult CompleteTask(int id)
    {
        _taskService.CompleteTask(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteTask(int id)
    {
        _taskService.DeleteTask(id); // تأكد من أن `DeleteTask` موجودة في `TaskService`
        return RedirectToAction("Index");
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