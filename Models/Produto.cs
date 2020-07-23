
using System.Collections.Generic;

namespace ApiComanda.Models
{
    public class Produto
    {

        public Produto() { }
        public Produto(int id, string prod_nome, double prod_preco, int categoriaId)
        {
            this.id = id;
            this.prod_nome = prod_nome;
            this.prod_preco = prod_preco;
            this.categoriaId = categoriaId;       
        }
        public int id { get; set; }
        public string prod_nome { get; set; }
        public double prod_preco { get; set; }
        public int categoriaId { get; set; }
        public Categoria categoria { get; set; }
    }
}