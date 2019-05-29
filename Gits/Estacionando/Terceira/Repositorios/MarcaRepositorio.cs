using System.Collections.Generic;
using System.IO;
using Terceira.Models;

namespace Terceira.Repositorios
{
    public class MarcaRepositorio
    {
        private const string PATH = "Database/Marcas.csv";
        private List<Marca> marcas = new List<Marca>();

        public List<Marca> ListarMarca() 
        {
            var registros = File.ReadAllLines(PATH);
            foreach (var item in registros)
            {
                var valores = item.Split(";");
                Marca marca = new Marca();
                marca.Id = int.Parse(valores[0]);
                marca.NomeMarca = valores[1];
                this.marcas.Add(marca);
            }
            return this.marcas;
        }
    }
}