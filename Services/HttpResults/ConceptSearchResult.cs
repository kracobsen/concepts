namespace Concepts.Services.HttpResults;

public class ConceptSearchResult
{
    public List<ConceptResult> Hits { get; set; }
    public ConceptPageResult Page { get; set; }
}