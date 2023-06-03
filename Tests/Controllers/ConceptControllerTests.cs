using Concepts.Controllers;
using Concepts.Models;
using Concepts.Services;

namespace ConceptTests;

public class ConceptControllerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task GetConceptTest()
    {
        var controller = new ConceptController(new ConceptService());
        var result = await controller.GetConcept("40938d13-eda7-406d-b6bc-fbe26506f6ac");
        Assert.AreEqual(result.Value.Id, "40938d13-eda7-406d-b6bc-fbe26506f6ac");
    }

    [Test]
    public async Task GetAllConceptsTest()
    {
        var controller = new ConceptController(new ConceptService());
        var result = await controller.Get();
        Assert.That(result.Value.Count(), Is.GreaterThanOrEqualTo(1));
    }
}