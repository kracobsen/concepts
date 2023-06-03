using Concepts.Services;
using Concepts.Services.ServiceResults;

namespace ConceptTests;

public class FakeConceptServiceReturnsCorrect : IConceptService
{
    public Task<ConceptServiceSearchResult> GetAllConcepts()
    {
        throw new NotImplementedException();
    }

    public Task<ConceptServiceGetResult> GetConceptById(string id)
    {
        throw new NotImplementedException();
    }
}