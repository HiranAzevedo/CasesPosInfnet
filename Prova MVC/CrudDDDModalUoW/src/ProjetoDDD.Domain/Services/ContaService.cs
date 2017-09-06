using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repository;
using ProjetoDDD.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjetoDDD.Domain.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            this.contaRepository = contaRepository;
        }

        public Conta Adicionar(Conta obj)
        {
            return contaRepository.Adicionar(obj);
        }

        public Conta Atualizar(Conta obj)
        {
            return contaRepository.Atualizar(obj);
        }

        public IEnumerable<Conta> Buscar(Expression<Func<Conta, bool>> predicate)
        {
            return contaRepository.Buscar(predicate);
        }

        public Conta ObterPorId(int id)
        {
            return contaRepository.ObterPorId(id);
        }

        public IEnumerable<Conta> ObterTodos()
        {
            return contaRepository.ObterTodos();
        }

        public void Remover(int id)
        {
            contaRepository.Remover(id);
        }

        public bool SaveChanges()
        {
            return contaRepository.SaveChanges();
        }
    }
}
