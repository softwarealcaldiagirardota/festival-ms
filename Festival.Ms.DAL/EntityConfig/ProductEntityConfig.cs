using System;
using Festival.Ms.DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Festival.Ms.DAL.EntityConfig
{
    public class ProductEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<ProductEntity> entityBuilder)
        {
            entityBuilder.ToTable("product");
            entityBuilder.HasKey(x => x.Id).HasName("products_pk");
            entityBuilder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entityBuilder.Property(p => p.Description).HasColumnName("description").IsRequired(false);
            entityBuilder.Property(p => p.CreatedAt).HasColumnName("created_at").IsRequired(false);
            entityBuilder.Property(p => p.Type).HasColumnName("type").IsRequired(false);
            entityBuilder.Property(p => p.Value).HasColumnName("value").IsRequired(false);

            entityBuilder.HasIndex(p => new { p.Id, p.Type }).HasDatabaseName("IX_prodcut");
        }
    }
}

