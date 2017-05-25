using SisAcad.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAcad.Persistencia.Config
{
    public class ProfessorConfig : EntityTypeConfiguration<Professor>
    {
        public ProfessorConfig()
        {
            ToTable("Professor");
            HasKey(p => p.ProfessorId);
            Property(p => p.Nome).HasMaxLength(150).IsRequired();
        }
    }
}
