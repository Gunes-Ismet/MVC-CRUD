﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CRUD.Infrastructure.EntityTypeConfiguration.Abstract;
using MVC_CRUD.Models.Entities.Concrete;

namespace MVC_CRUD.Infrastructure.EntityTypeConfiguration.Concrete
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(600).IsRequired(true);

            base.Configure(builder);
        }
    }
}
