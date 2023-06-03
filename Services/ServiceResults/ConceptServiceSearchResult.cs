using Concepts.Models;

namespace Concepts.Services.ServiceResults;

public class ConceptServiceSearchResult
{
    public bool Success { get; set; }
    public IEnumerable<Concept> Concepts { get; set; }
}