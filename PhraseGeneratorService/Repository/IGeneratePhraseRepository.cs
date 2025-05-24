namespace PhraseGeneratorDomain.Repository
{
    public interface IGeneratePhraseRepository
    {
        Task<(string Content, string Author)> GetRandomQuoteAsync(int? minLength = null, int? maxLength = null);
    }
}
