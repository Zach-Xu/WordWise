using backend.Entity.Word;

namespace backend.Services
{
    public interface ITranslateService
    {
        Task<Translation> TranslateWordAsync(string word, Language language);
    }
}
