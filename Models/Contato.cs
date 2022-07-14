using System;

namespace TVox.Models
{
    [Serializable]
    public class  Contato
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Idade { get; set; }

        public string Telefone { get; set; }

        public string Genero { get; set; }

        public string DataCadastro { get; set; }

    }
}
