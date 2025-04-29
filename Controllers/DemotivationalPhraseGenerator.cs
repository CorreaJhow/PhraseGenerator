using Microsoft.AspNetCore.Mvc;

namespace PhraseGenerator.Controllers
{
    [ApiController]
    [Route("/v1/")]
    public class DemotivationalPhraseGenerator
    {
        public DemotivationalPhraseGenerator() { }

        [HttpGet("demotivationalPhrase")]
        public string GetPhrase()
        {
            return "esta funcionando";
        }
    }
}
