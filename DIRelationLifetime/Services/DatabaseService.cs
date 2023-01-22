using DIRelationLifetime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DIRelationLifetime.Services
{
    public class DatabaseService
    {
        private readonly ISingletonService _singleton;
        private readonly IScopedService _scoped;
        private readonly ITransientService _transient;

        public DatabaseService(ISingletonService singleton, IScopedService scoped, ITransientService transient)
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
        }

        public void Save()
        {
            Console.WriteLine("\n|||||||| DatabaseService |||||||| \n");
            Console.WriteLine($"Singleton UID:\t\t {_singleton.ServiceUniqueIdentifier}");
            Console.WriteLine($"SCoped UID:\t\t {_scoped.ServiceUniqueIdentifier}");
            Console.WriteLine($"Transientn UID:\t\t {_transient.ServiceUniqueIdentifier}");

            
        }
    }
}
