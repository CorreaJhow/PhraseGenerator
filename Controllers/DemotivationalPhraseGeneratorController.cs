using Microsoft.AspNetCore.Mvc;

namespace PhraseGenerator.Controllers
{
    [ApiController]
    [Route("/v1/")]
    public class DemotivationalPhraseGeneratorController
    {
        private readonly ISearchPhraseRandomDemotivational _searchPhraseRandomDemotivational;
        public DemotivationalPhraseGeneratorController(ISearchPhraseRandomDemotivational searchPhraseRandomDemotivational) 
        {
            _searchPhraseRandomDemotivational = searchPhraseRandomDemotivational;
        }

        [HttpGet("Random/DemotivationalPhrase")]
        public async Task<IActionResult> GetPhrase()
        {
            return await Ok("esta funcionando");
        }

        [HttpGet("SpecificTheme/DemotivationalPhrase")]
        public async Task<IActionResult> GetSpecificThemePhrase([FromQuery] string theme)
        {
            return await Ok("esta funcionando");
        }
    }
}
