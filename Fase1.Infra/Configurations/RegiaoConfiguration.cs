using Fase1.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase1.Infra.Configurations
{
    public class RegiaoConfiguration : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {
            builder.ToTable("Regiao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(x => x.DDD).HasColumnType("VARCHAR(3)").IsRequired();
            builder.HasMany(r => r.Contatos)
                .WithOne(c => c.Regiao)
                .HasPrincipalKey(r => r.Id);
        }
    }
}
