
using System.Collections.Generic;

namespace ApiComanda.Models
{
    public class Comanda
    {

        public Comanda() { }
        public Comanda(int id, int numero, int qtde)
        {
            this.id = id;
            this.numero = numero;
            this.qtde = qtde;
        }
        public int id { get; set; }
        public int numero { get; set; }
        public int qtde { get; set; }
        public IEnumerable<ComandaProduto> comandasprodutos { get; set; }
    }
}
