using System;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Festival.Ms.DAL.EntityConfig
{
    public static class FestivalEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<FestivalEntity> entityBuilder)
        {
            entityBuilder.ToTable("festival");
            entityBuilder.HasKey(x => x.Id).HasName("PK_festival");
            entityBuilder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entityBuilder.Property(p => p.Description).IsRequired().HasMaxLength(500).HasColumnName("description");
            entityBuilder.Property(p => p.Question).HasColumnName("question");

            entityBuilder.HasIndex(p => new { p.Question, p.Id }).HasDatabaseName("IX_Festival_Question");

        }
    }
}

