using backend.Entity.Word;

namespace backend.Utils
{
    public interface ILanguageMapper
    {
        string GetLanguageCode(Language language);
    }
}
