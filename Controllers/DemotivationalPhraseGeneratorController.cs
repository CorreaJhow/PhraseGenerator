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

        /// <summary>
        /// Gera frase desmotivacional aleatoria
        /// </summary>
        /// <returns></returns>
        [HttpGet("Random/DemotivationalPhrase")]
        public async Task<IActionResult> GetPhrase()
        {
            var randomPhrase = await _searchPhraseRandomDemotivational.GenerateRandomPhraseDemotivational();
            if(randomPhrase == null)
                return NotFound("failure, sentence not generated");

            return Ok(randomPhrase);
        }
        s
        /// <summary>
        /// Busca frase desmotivacional com tema especifico
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        [HttpGet("SpecificTheme/DemotivationalPhrase")]
        public async Task<IActionResult> GetSpecificThemePhrase([FromQuery] string theme)
        {
            return Ok($"The phrase will return here, when it works, with the theme: {theme}");
        }
    }
}
