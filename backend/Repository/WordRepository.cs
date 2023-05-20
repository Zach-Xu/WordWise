using backend.Entity;
using backend.Entity.Word;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class WordRepository
    {
        private readonly WordDbContext dbContext;

        public WordRepository(WordDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<WordRecord> CreateWordRecordAsnyc(WordRecord wordRecord)
        {
            await dbContext.WordRecords.AddAsync(wordRecord);
            await dbContext.SaveChangesAsync();
            return wordRecord;
        }

        public async Task<WordRecord[]> GetWordRecordsByDateAsync(DateTime date)
        {
            var wordRecords = await dbContext.WordRecords.Where(w => w.CreatedTime.Date == date.Date)
                .ToArrayAsync();
            return wordRecords;
        }

        public async Task<WordRecord[]> GetWordRecordsByDateAndLanguageAsync(DateTime date, Language language = Language.Chinese)
        {
            var wordRecords = await dbContext.WordRecords.Where(w => w.CreatedTime.Date == date.Date && w.Translation.Language == language)
                .ToArrayAsync();
            return wordRecords;
        }

        public async Task<WordRecord[]> GetWordRecordsAsync(int pageNum, int pageSize = 20)
        {
            var wordRecords = await dbContext.WordRecords.Skip((pageNum - 1) * pageSize)
                .Take(pageSize).ToArrayAsync();
            return wordRecords;
        }
    }
}
