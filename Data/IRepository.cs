using System.Threading.Tasks;
using ApiComanda.Models;

namespace ApiComanda.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //ALUNO
        Task<Comanda[]> GetAllComandasAsync(bool includeProduto);                
        Task<Comanda> GetComandaAsyncById(int comandaId, bool includeProduto);
        Task<Produto[]> GetAllProdutosAsync(bool includeCategoria);        
        Task<Produto> GetProdutoAsyncById(int produtoId, bool includeCategoria);
        Task<Categoria[]> GetAllCategoriasAsync();        
        Task<Categoria> GetCategoriaAsyncById(int categoriaId);
    }
}