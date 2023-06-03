using Concepts.Services.HttpResults;

namespace Concepts.Services;

public class ConceptResult
{
    public string Id { get; set; }
    public ConceptDialectResult PrefLabel { get; set; }
    public ConceptDialectResult[] AltLabel { get; set; }
    public ConceptDialectResult Subject { get; set; }
    public ConceptDefinitionResult Definition { get; set; }

   
}