namespace Concepts.Models;

public class Concept
{
    public string Id { get; set; }
    public string Subject { get; set; }
    public string PrefLabel { get; set; }
    public string AltLabel { get; set; }
    public ConceptDefinition Definition { get; set; }

    public class ConceptDefinition
    {
        public string Tekst { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}