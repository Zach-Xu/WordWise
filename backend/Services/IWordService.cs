using backend.Entity.Word;

namespace backend.Services
{
    public interface IWordService
    {
        Task<WordRecord> CreateWordRecordAsync(WordRecord wordRecord);
        Task<WordRecord[]> GetWordRecordsAsync(int pageNum, int pageSize);
        Task<WordRecord[]> GetWordRecordsByDateAsync(DateTime date);
        Task<WordRecord[]> GetWordRecordsByDateAndLanguageAsync(DateTime date, Language language);
    }
}
