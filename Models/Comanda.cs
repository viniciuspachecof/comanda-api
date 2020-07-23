
using System.Collections.Generic;

namespace ApiComanda.Models
{
    public class Comanda
    {

        public Comanda() { }
        public Comanda(int id, int numero_comanda, int quantidade, char situacao)
        {
            this.id = id;
            this.numero_comanda = numero_comanda;
            this.quantidade = quantidade;
            this.situacao = situacao;
        }
        public int id { get; set; }
        public int numero_comanda { get; set; }
        public int quantidade { get; set; }
        public char situacao {get; set; }
        public IEnumerable<ComandaProduto> comandasprodutos { get; set; }
    }
}
