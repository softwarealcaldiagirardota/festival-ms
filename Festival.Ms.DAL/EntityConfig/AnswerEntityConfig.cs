using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Festival.Ms.DAL.EntityConfig
{
    public class AnswerEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<AnswerEntity> entityBuilder)
        {
            entityBuilder.ToTable("answer");
            entityBuilder.HasKey(x => x.Id).HasName("answers_pk");
            entityBuilder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entityBuilder.Property(p => p.Description).HasColumnName("description").IsRequired(false);
            entityBuilder.Property(p => p.Value).HasColumnName("value");
            entityBuilder.HasIndex(p => p.Id).HasDatabaseName("IX_Idanswer");
        }
    }
}

