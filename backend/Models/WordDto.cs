using backend.Entity.Word;

namespace backend.Models
{
    public record WordDto
    {
        public String Word { get; set; }
        public Language Language { get; set; }

        public WordDto(string word, Language language)
        {
            Word = word;
            Language = language;
        }
    }
}
