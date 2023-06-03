using Concepts.Models;
using Concepts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Concepts.Controllers;

[ApiController]
[Route("[controller]")]
public class ConceptController : ControllerBase
{
    private readonly IConceptService service;

    public ConceptController(IConceptService service)
    {
        this.service = service;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Concept> Get()
    {
        return this.service.GetAllConcepts().ToArray();
    }
}