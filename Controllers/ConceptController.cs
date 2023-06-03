using Concepts.Models;
using Concepts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Concepts.Controllers;

[ApiController]
[Route("begrep")]
public class ConceptController : ControllerBase
{
    private readonly IConceptService service;

    public ConceptController(IConceptService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Concept>>> Get()
    {
        var result = await this.service.GetAllConcepts();
        if (result.Success)
        {
            return new ActionResult<IEnumerable<Concept>>(result.Concepts);
        }

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Concept>> GetConcept(string id)
    {
        var result = await this.service.GetConceptById(id);
        if (result.Success)
        {
            return result.Concept;
        }

        return BadRequest();
    }
    
}