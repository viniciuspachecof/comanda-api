using System.Collections.Generic;

namespace ApiComanda.Models
{
    public class Categoria
    {
        public Categoria() { }
        public Categoria(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }

        public int id { get; set; }
        public string descricao { get; set; }       
    }
}