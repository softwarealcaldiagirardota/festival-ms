using System;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Festival.Ms.DAL.EntityConfig
{
    public static class VoteEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<VoteEntity> entityBuilder)
        {
            entityBuilder.ToTable("vote");

            entityBuilder.HasKey(x => x.Id)
                .HasName("votes_pk");

            entityBuilder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entityBuilder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamptz");

            entityBuilder.Property(p => p.IdQuestion)
                .HasColumnName("id_question")
                .HasColumnType("bigint");

            entityBuilder.Property(p => p.IdAnswer)
                .HasColumnName("id_answer")
                .HasColumnType("bigint");

            entityBuilder.Property(p => p.IdParticipationCompany)
                .HasColumnName("id_participation_company")
                .HasColumnType("bigint");
        }
    }
}

