﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Entity.Word
{
    public class WordRecordEntityConfig : IEntityTypeConfiguration<WordRecord>
    {
        public void Configure(EntityTypeBuilder<WordRecord> builder)
        {
            builder.ToTable("T_WordRecord");
            builder.OwnsOne(w => w.Translation);
            builder.Property(w => w.IsMemorized).HasDefaultValue(false);
            builder.Property(w => w.Frequency).HasDefaultValue(1);
        }
    }
}
