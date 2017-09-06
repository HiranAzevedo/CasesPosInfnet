using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using AutoMapper;
using ProjetoDDD.Application.Interfaces;
using ProjetoDDD.Application.ViewModels;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Service;
using ProjetoDDD.Infra.Data.Interfaces;

namespace ProjetoDDD.Application
{
    public class ClienteAppService : ApplicationService, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork uow)
            : base(uow)
        {
            _clienteService = clienteService;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<ClienteEnderecoViewModel, Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<ClienteEnderecoViewModel, Endereco>(clienteEnderecoViewModel);

            cliente.Enderecos.Add(endereco);
            var foto = clienteEnderecoViewModel.Foto;

            BeginTransaction();

            var clienteReturn = _clienteService.Adicionar(cliente);
            clienteEnderecoViewModel = Mapper.Map<Cliente, ClienteEnderecoViewModel>(clienteReturn);
            if (!clienteReturn.ValidationResult.IsValid)
            {
                // Não faz o commit
                return clienteEnderecoViewModel;
            }

            if (!SalvarImagemCliente(foto, clienteEnderecoViewModel.ClienteId))
            {
                // Tomada de decisão caso a imagem não seja gravada.
                clienteEnderecoViewModel.ValidationResult.Message = "Cliente salvo sem foto";
            }

            Commit();

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.ObterTodos());
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            BeginTransaction();
            _clienteService.Atualizar(Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel));
            Commit();
            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            BeginTransaction();
            _clienteService.Remover(id);
            Commit();
        }

        public EnderecoViewModel AdicionarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);
            
            BeginTransaction();
            _clienteService.AdicionarEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _clienteService.AtualizarEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel ObterEnderecoPorId(Guid id)
        {
            return Mapper.Map<Endereco, EnderecoViewModel>(_clienteService.ObterEnderecoPorId(id));
        }

        public void RemoverEndereco(Guid id)
        {
            BeginTransaction();
            _clienteService.RemoverEndereco(id);
            Commit();
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }

        private static bool SalvarImagemCliente(HttpPostedFileBase img, Guid id)
        {
            if (img == null || img.ContentLength <= 0) return false;

            const string directory = @"D:\Labs\CursoMVC Update\src\contents\clientes\";
            var fileName = id + Path.GetExtension(img.FileName);
            img.SaveAs(Path.Combine(directory, fileName));
            return File.Exists(Path.Combine(directory, fileName));
        }
    }
}