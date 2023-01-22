using DIRelationLifetime.Services.Interfaces;

namespace DIRelationLifetime.Services
{
    public class TestService : ISingletonService, IScopedService, ITransientService
    {
        public string ServiceUniqueIdentifier { get; } = Guid.NewGuid().ToString();

    }
}
