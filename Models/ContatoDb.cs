using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TVox.Models
{
    public class ContatoDb
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Telefone { get; set; }

        public string Genero { get; set; }

        public string DataCadastro { get; set; }

    }
}