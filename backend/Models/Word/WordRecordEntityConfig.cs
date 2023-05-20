using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Word
{
    public class WordRecordEntityConfig : IEntityTypeConfiguration<WordRecord>
    {
        public void Configure(EntityTypeBuilder<WordRecord> builder)
        {
            builder.ToTable("T_WordRecord");
            builder.OwnsOne(w => w.Translation);
        }
    }
}
