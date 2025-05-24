using Newtonsoft.Json.Linq;
using PhraseGeneratorDomain.Repository;

namespace PhraseGeneratorRepository
{
    public class GeneratePhraseRepository : IGeneratePhraseRepository
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://api.realinspire.live/v1/quotes/random";

        public GeneratePhraseRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Gets a random phrase from the Real Inspire API rs.
        /// </summary>
        /// <param name="minLength">Minimum sentence length</param>
        /// <param name="maxLength">Comprimento máximo da frase.</param>
        /// <returns>Text and Author</returns>
        public async Task<(string Content, string Author)> GetRandomQuoteAsync(int? minLength = null, int? maxLength = null)
        {
            var url = ApiUrl;

            if (minLength.HasValue || maxLength.HasValue)
            {
                url += "?";
                if (minLength.HasValue)
                    url += $"minLength={minLength.Value}&";
                if (maxLength.HasValue)
                    url += $"maxLength={maxLength.Value}&";
                url = url.TrimEnd('&');
            }

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var jsonArray = JArray.Parse(responseBody);
                if (jsonArray.Count == 0)
                    throw new Exception("No phrase returned by API.");

                var quote = jsonArray[0];
                string content = quote["content"]?.ToString();
                string author = quote["author"]?.ToString();

                return (content, author);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error consuming API | Error : {ex}");
            }
        }
    }
}
