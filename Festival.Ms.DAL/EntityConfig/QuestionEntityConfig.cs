using System;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Festival.Ms.DAL.EntityConfig
{
    public class QuestionEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<QuestionEntity> entityBuilder)
        {
            entityBuilder.ToTable("question");
            entityBuilder.HasKey(x => x.Id).HasName("Questions_pk");
            entityBuilder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entityBuilder.Property(p => p.Description).HasColumnName("description").IsRequired(false);
            entityBuilder.Property(p => p.Value).HasColumnName("value");

            entityBuilder.HasIndex(p => p.Id).HasDatabaseName("IX_question");
        }
    }
}

