using Microsoft.AspNetCore.Mvc;
using PhraseGeneratorDomain.Interfaces;

namespace PhraseGenerator.Controllers
{
    [ApiController]
    [Route("/v1/")]
    public class DemotivationalPhraseGeneratorController : ControllerBase
    {
        private readonly ISearchPhraseRandomDemotivational _searchPhraseRandomDemotivational;
        public DemotivationalPhraseGeneratorController(ISearchPhraseRandomDemotivational searchPhraseRandomDemotivational) 
        {
            _searchPhraseRandomDemotivational = searchPhraseRandomDemotivational;
        }

        [HttpGet("Random/DemotivationalPhrase")]
        public async Task<IActionResult> GetPhrase()
        {
            var randomPhrase = await _searchPhraseRandomDemotivational.GenerateRandomPhraseDemotivational();
            if(randomPhrase == null)
                return NotFound("failure, sentence not generated");

            return Ok(randomPhrase);
        }

        [HttpGet("SpecificTheme/DemotivationalPhrase")]
        public async Task<IActionResult> GetSpecificThemePhrase([FromQuery] string theme)
        {
            return Ok($"The phrase will return here, when it works, with the theme: {theme}");
        }
    }
}
