using Concepts.Models;

namespace Concepts.Services.ServiceResults;

public class ConceptServiceGetResult
{
    public bool Success { get; set; }
    public Concept Concept { get; set; }
}