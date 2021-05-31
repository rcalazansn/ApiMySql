using ApiMySql.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMySql.Data
{
    public class ClienteRepository : IClienteRepository
    {
        protected readonly ApiContext _context;
        public ClienteRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Cliente cliente)
        {
            await _context.AddAsync(cliente);

            await _context.SaveChangesAsync();
        }

        public async Task Editar(Cliente cliente)
        {
            await _context.SaveChangesAsync();
        }
        public async Task<Cliente> Obter(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> Obter()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }
        public async Task Remover(Cliente cliente)
        {
            _context.Remove(cliente);

            await _context.SaveChangesAsync();
        }
    }
}
