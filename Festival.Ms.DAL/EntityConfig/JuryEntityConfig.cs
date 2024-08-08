using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.EntityConfig
{
    public class JuryEntityConfig
    {

        public static void SetEntityBuilder(EntityTypeBuilder<JuryEntity> entityBuilder)
        {
            entityBuilder.ToTable("jury");

            entityBuilder.HasKey(x => x.Id).HasName("jury_pk");

            entityBuilder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entityBuilder.Property(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("varchar");

            entityBuilder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamptz");

            entityBuilder.Property(p => p.IdUserAuth)
                .HasColumnName("id_user_auth")
                .HasColumnType("bigint");

            entityBuilder.HasIndex(p => p.Id).HasDatabaseName("IX_IdJury");
            entityBuilder.HasIndex(p => p.IdUserAuth).HasDatabaseName("IX_id_user_auth");
        }
    }
}

