namespace backend.Entity.Word
{
    public class WordRecord
    {
        public long Id { get; set; }
        public string EnglishWord { get; set; }
        public Translation Translation { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsMemorized { get; set; }
        public int Frequency { get; set; }
    }
}
