using System.Collections.Generic;
using System.IO;
using Terceira.Models;

namespace Terceira.Repositorios
{
    public class ModeloRepositorio
    {
        private const string PATH = "Database/Modelo.csv";
        private List<Modelo> modelos = new List<Modelo>();

        public List<Modelo> ListarModelo() 
        {
            var registros = File.ReadAllLines(PATH);
            foreach (var item in registros)
            {
                var valores = item.Split(";");
                Modelo modelo = new Modelo();
                modelo.Nome = valores[0];
                modelo.Marca = valores[1];

                this.modelos.Add(modelo);
            }
            return this.modelos;
        }
    }
}