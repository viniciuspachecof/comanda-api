
using System.Collections.Generic;

namespace ApiComanda.Models
{
    public class Produto
    {

        public Produto() { }
        public Produto(int id, string nome, double valor, string observacao, int categoriaId)
        {
            this.id = id;
            this.nome = nome;
            this.valor = valor;
            this.observacao = observacao;
            this.categoriaId = categoriaId;       
        }
        public int id { get; set; }
        public string nome { get; set; }
        public double valor { get; set; }
        public string observacao { get; set; }
        public int categoriaId { get; set; }
        public Categoria categoria { get; set; }
    }
}