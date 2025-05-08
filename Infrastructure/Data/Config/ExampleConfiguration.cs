using Core.Aggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config;
public class ExampleConfiguration : IEntityTypeConfiguration<Example>
{
    public void Configure(EntityTypeBuilder<Example> builder)
    {
        builder.ToTable("example");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id).HasColumnName("id").IsRequired();

        builder.Property(e => e.stProperty).HasColumnName("st_property").HasMaxLength(128).IsRequired();
        builder.Property(e => e.boProperty).HasColumnName("bo_property").IsRequired();
        builder.Property(e => e.IsDeleted).HasColumnName("is_deleted").IsRequired();
        builder.Property(e => e.CreatedBy).HasColumnName("is_deleted").IsRequired(false);
        builder.Property(e => e.CreatedAt).HasColumnName("is_deleted").IsRequired();
        builder.Property(e => e.UpdatedBy).HasColumnName("is_deleted").IsRequired(false);
        builder.Property(e => e.UpdatedAt).HasColumnName("is_deleted").IsRequired();
    }

    private void Seed(EntityTypeBuilder<Example> builder) => builder.HasData(
        new Example
        {
            Id = new Guid("00000000-0000-0000-0000-000000000001"),
            stProperty = "Example 1",
            boProperty = false,
            IsDeleted = false
        },
        new Example
        {
            Id = new Guid("00000000-0000-0000-0000-000000000002"),
            stProperty = "Example 2",
            boProperty = false,
            IsDeleted = false
        },
        new Example
        {
            Id = new Guid("00000000-0000-0000-0000-000000000003"),
            stProperty = "Example 3",
            boProperty = false,
            IsDeleted = false
        });
}