using DIRelationLifetime.Services;
using DIRelationLifetime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DIRelationLifetime.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TestController : ControllerBase
    {
        private readonly ISingletonService _singleton;
        private readonly IScopedService _scoped;
        private readonly ITransientService _transient;
        private readonly DatabaseService _dbService;

        public TestController(ISingletonService singleton, IScopedService scoped, ITransientService transient, DatabaseService dbService)
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
            _dbService = dbService;
        }

        public IActionResult Get()
        {
            Console.WriteLine("\n|||||||| TestController |||||||| \n");
            Console.WriteLine($"Singleton UID:\t\t {_singleton.ServiceUniqueIdentifier}");
            Console.WriteLine($"SCoped UID:\t\t {_scoped.ServiceUniqueIdentifier}");
            Console.WriteLine($"Transientn UID:\t\t {_transient.ServiceUniqueIdentifier}");

            _dbService.Save();

            return Ok();
        }
    }
}
