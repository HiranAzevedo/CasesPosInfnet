using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repository;
using ProjetoDDD.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjetoDDD.Domain.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly IPerfilRepository perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository)
        {
            this.perfilRepository = perfilRepository;
        }

        public Perfil Adicionar(Perfil obj)
        {
            return perfilRepository.Adicionar(obj);
        }

        public Perfil Atualizar(Perfil obj)
        {
            return perfilRepository.Atualizar(obj);
        }

        public IEnumerable<Perfil> Buscar(Expression<Func<Perfil, bool>> predicate)
        {
            return perfilRepository.Buscar(predicate);
        }

        public Perfil ObterPorId(int id)
        {
            return perfilRepository.ObterPorId(id);
        }

        public IEnumerable<Perfil> ObterTodos()
        {
            return perfilRepository.ObterTodos();
        }

        public void Remover(int id)
        {
            perfilRepository.Remover(id);
        }

        public bool SaveChanges()
        {
            return perfilRepository.SaveChanges();
        }
    }
}
