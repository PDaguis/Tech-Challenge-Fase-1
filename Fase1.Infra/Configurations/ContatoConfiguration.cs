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
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(x => x.CadastradoEm).HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(300)").IsRequired();
            builder.HasOne(c => c.Regiao)
                .WithMany(r => r.Contatos)
                .HasPrincipalKey(r => r.Id);
        }
    }
}
