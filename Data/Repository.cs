using System.Linq;
using System.Threading.Tasks;
using ApiComanda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiComanda.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        // COMANDA
        public async Task<Comanda[]> GetAllComandasAsync(bool includeProduto)
        {
            IQueryable<Comanda> query = _context.comanda;

            if (includeProduto)
            {
                query = query.Include(c => c.comandasprodutos)
                             .ThenInclude(cp => cp.produto)
                             .ThenInclude(p => p.categoria);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }

        public async Task<Comanda> GetComandaAsyncById(int comandaId, bool includeProduto)
        {
            IQueryable<Comanda> query = _context.comanda;

            if (includeProduto)
            {
                query = query.Include(c => c.comandasprodutos)
                             .ThenInclude(cp => cp.produto)
                             .ThenInclude(p => p.categoria);
            }

            query = query.AsNoTracking()
                         .OrderBy(comanda => comanda.id)
                         .Where(comanda => comanda.id == comandaId);

            return await query.FirstOrDefaultAsync();
        }

        // PRODUTO
        public async Task<Produto[]> GetAllProdutosAsync(bool includeCategoria)
        {
            IQueryable<Produto> query = _context.produto;

            if (includeCategoria)
            {
                query = query.Include(p => p.categoria);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.id);

            return await query.ToArrayAsync();
        }

        public async Task<Produto> GetProdutoAsyncById(int produtoId, bool includeCategoria)
        {
            IQueryable<Produto> query = _context.produto;

            if (includeCategoria)
            {
                query = query.Include(p => p.categoria);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.id)
                         .Where(p => p.id == produtoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Categoria[]> GetAllCategoriasAsync()
        {
            IQueryable<Categoria> query = _context.categoria;

            query = query.AsNoTracking()
                         .OrderBy(ca => ca.id);

            return await query.ToArrayAsync();
        }

        public async Task<Categoria> GetCategoriaAsyncById(int categoriaId)
        {
            IQueryable<Categoria> query = _context.categoria;

            query = query.AsNoTracking()
                         .OrderBy(categoria => categoria.id)
                         .Where(categoria => categoria.id == categoriaId);

            return await query.FirstOrDefaultAsync();
        }

    }
}