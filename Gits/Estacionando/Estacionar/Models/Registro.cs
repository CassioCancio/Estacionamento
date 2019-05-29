using System;

namespace Estacionar.Models
{
    public class Registro
    {
        public string NomeUsuario {get;set;}
        public string PlacaCarro {get;set;}
        public string ModeloCarro {get;set;}
        public string MarcaCarro {get;set;}
        public DateTime DataEntrada {get;set;}
    }
}