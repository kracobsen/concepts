using System.Text.Json;
using System.Text.Json.Nodes;
using Concepts.Models;
using Concepts.Services.HttpResults;
using Concepts.Services.ServiceResults;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Concepts.Services;

public interface IConceptService
{
    public Task<ConceptServiceSearchResult> GetAllConcepts();
    Task<ConceptServiceGetResult> GetConceptById(string id);
}

public class ConceptService : IConceptService
{
    public async Task<ConceptServiceSearchResult> GetAllConcepts()
    {
        var conceptList = new List<Concept>();
        var options = new RestClientOptions("https://search.fellesdatakatalog.digdir.no");
        var client = new RestClient(options);
        var lastPage = false;
        var currentPage = 0;

        while (!lastPage)
        {
            var request = new RestRequest("concepts").AddJsonBody(new { page = currentPage });
            var result = await client.PostAsync<ConceptSearchResult>(request);

            foreach (var conceptResult in result.Hits)
            {
                conceptList.Add(this.ConvertResultToConcept(conceptResult));
            }

            if (result.Page.TotalPages <= currentPage)
            {
                lastPage = true;
            }

            currentPage += 1;
        }

        return new ConceptServiceSearchResult()
        {
            Concepts = conceptList,
            Success = true
        };
    }

    public async Task<ConceptServiceGetResult> GetConceptById(string id)
    {
        var options = new RestClientOptions("https://fellesdatakatalog.digdir.no/api");
        var client = new RestClient(options);
        var request = new RestRequest($"concepts/{id}");

        ConceptResult result = null;
        try
        {
            result = await client.GetAsync<ConceptResult>(request);
        }
        catch (Exception e)
        {
            return new ConceptServiceGetResult()
            {
                Success = false
            };
        }
        return new ConceptServiceGetResult()
        {
            Success = true,
            Concept = ConvertResultToConcept(result)
        };
    }

    private Concept ConvertResultToConcept(ConceptResult result)
    {
        return new Concept
        {
            Definition = new Concept.ConceptDefinition()
            {
                LastUpdated = result.Definition.LastUpdated,
                Tekst = result.Definition.Text.NB
            },
            Id = result.Id,
            AltLabel = result.AltLabel == null
                ? string.Empty
                : (result.AltLabel.Length == 0 ? string.Empty : result.AltLabel[0].NB),
            PrefLabel = result.PrefLabel.NB,
            Subject = result.Subject?.NB ?? string.Empty
        };
    }
}