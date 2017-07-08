using Infnet.SIFISCON.Domain.Entities;
using Infnet.SIFISCON.Domain.Interfaces.Repositories;

namespace Infnet.SIFISCON.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>
    {
        private IRepositoryBase<Produto> _produtoRepository;

        public ProdutoService(IRepositoryBase<Produto> repository) : base(repository)
        {
            _produtoRepository = repository;
        }
    }
}
