using Concepts.Models;

namespace Concepts.Services;

public interface IConceptService
{
    public IEnumerable<Concept> GetAllConcepts();
}

public class ConceptService : IConceptService
{
    public IEnumerable<Concept> GetAllConcepts()
    {
        return new[]
        {
            new Concept()
            {
                AltLabel = "Test",
                Definition = new Concept.ConceptDefinition() { LastUpdated = DateOnly.MaxValue, Tekst = "Text" },
                Id = "1",
                PrefLabel = "Test",
                Subject = "Test"
            }
        };
    }
}