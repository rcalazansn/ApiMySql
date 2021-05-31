using ApiMySql.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMySql.Data
{
    public interface IClienteRepository
    {
        Task Adicionar(Cliente cliente);
        Task Editar(Cliente cliente);
        Task<Cliente> Obter(int id);
        Task<IEnumerable<Cliente>> Obter();
        Task Remover(Cliente cliente);
    }
}
