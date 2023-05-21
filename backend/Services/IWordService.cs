using backend.Entity.Word;
using backend.Models;

namespace backend.Services
{
    public interface IWordService
    {
        Task<WordRecord> CreateWordRecordAsync(WordDto wordDto);
        Task<WordRecord[]> GetWordRecordsAsync(int pageNum, int pageSize);
        Task<WordRecord[]> GetWordRecordsByDateAsync(DateTime date);
        Task<WordRecord[]> GetWordRecordsByDateAndLanguageAsync(DateTime date, Language language);
    }
}
