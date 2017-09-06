using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repository;
using ProjetoDDD.Infra.Data.Context;

namespace ProjetoDDD.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {

        public ClienteRepository(ProjetoDDDContext context)
            : base(context)
        {
            
        }

        public Cliente ObterPorCpf(string cpf)
        {
            //return Db.Clientes.FirstOrDefault(c => c.CPF == cpf);
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Clientes";

            return cn.Query<Cliente>(sql);
        }

        public override Cliente ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Clientes c " +
                       "LEFT JOIN Enderecos e " +
                       "ON c.ClienteId = e.ClienteId " +
                       "WHERE c.ClienteId = @sid";

            var cliente = new List<Cliente>();
            cn.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) =>
                {
                    cliente.Add(c);
                    if(e != null)
                        cliente[0].Enderecos.Add(e);

                    return cliente.FirstOrDefault();
                }, new { sid = id }, splitOn: "ClienteId, EnderecoId");

            return cliente.FirstOrDefault();
        }
    }
}