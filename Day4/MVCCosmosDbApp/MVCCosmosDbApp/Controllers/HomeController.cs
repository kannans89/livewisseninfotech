using Microsoft.AspNetCore.Mvc;
using MVCCosmosDbApp.Models;
using MVCCosmosDbApp.Services;
using System.Diagnostics;

namespace MVCCosmosDbApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConfigModel _configOptions;

        public HomeController(ILogger<HomeController> logger, ConfigModel configOptions)
        {
            _logger = logger;
            _configOptions = configOptions;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewTodos()
        {

            TodoService db = new TodoService(_configOptions.CosomosdbConnectionString, _configOptions.CosmosdbDatabaseName, _configOptions.CosmosdbContainerName);
            List<Todo> todos = await db.GetTodosAsync();

            return View(todos);

        }
        public IActionResult AddTodo()
        {
            Todo model = new Todo();
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(Todo model)
        {

            TodoService db = new TodoService(_configOptions.CosomosdbConnectionString, _configOptions.CosmosdbDatabaseName, _configOptions.CosmosdbContainerName);
            bool result = await db.AddTodo(model);

            if (result)
                return RedirectToAction("ViewTodos");
            else
                return NotFound();

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
