using SisAcad.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAcad.Persistencia.Config
{
    public class UsuarioConfig: EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            ToTable("Usuario");
            HasKey(u => u.UsuarioId);
        }
    }
}
