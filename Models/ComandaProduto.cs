namespace ApiComanda.Models
{
    public class ComandaProduto
    {
        public ComandaProduto() { }        
        public ComandaProduto(int comandaId, Comanda comanda, int produtoId, Produto produto)
        {
            this.comandaId = comandaId;
            this.comanda = comanda;
            this.produtoId = produtoId;
            this.produto = produto;            
        }
        public int comandaId { get; set; }
        public Comanda comanda { get; set; }
        public int produtoId { get; set; }
        public Produto produto { get; set; }
    }
}