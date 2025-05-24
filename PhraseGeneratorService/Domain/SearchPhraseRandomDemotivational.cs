using PhraseGeneratorDomain.Interfaces;
using PhraseGeneratorDomain.Repository;

namespace PhraseGeneratorDomain.Domain
{
    public class SearchPhraseRandomDemotivational : ISearchPhraseRandomDemotivational
    {
        private readonly IGeneratePhraseRepository _generatePhraseRepository;

        public SearchPhraseRandomDemotivational(IGeneratePhraseRepository generatePhraseRepository)
        {
            _generatePhraseRepository = generatePhraseRepository;
        }

        public async Task<string> GenerateRandomPhraseDemotivational()
        {
            Console.WriteLine($"Start Method: GenerateRandomPhraseDemotivational | Timestamp : {DateTime.Now.TimeOfDay}");

            var randomPhrase = await _generatePhraseRepository.GetRandomQuoteAsync();

            if(randomPhrase ) //criar retorno. 
        }
    }
}
