using System;
using System.Collections.Generic;
using System.IO;
using Terceira.Models;

namespace Terceira.Repositorios {
    public class RegistroRepositorio {
        private const string PATH = "Database/Registro.csv";
        private List<Registro> registros = new List<Registro> ();

        public List<Registro> Listar () {
            var leitor = File.ReadAllLines (PATH);
            foreach (var item in leitor) {
                if(item != null){
                var valores = item.Split (";");
                Registro registro = new Registro ();
                registro.NomeUsuario = valores[0];
                registro.Placa = valores[1];
                registro.Marca = valores[2];
                registro.NomeModelo = valores[3];
                registro.DataRegistro = DateTime.Parse (valores[4]);

                registros.Add (registro);
                }
            }
            return registros;
        }
        private string Path = "Database/Registro.csv";
        public void Gravar (Registro registro) {
            if (!File.Exists (Path)) {
                File.Create (Path).Close ();
            }

            var linha = $"{registro.NomeUsuario};{registro.Placa};{registro.Marca};{registro.NomeModelo};{registro.DataRegistro}";

            File.AppendAllText (Path, linha + "\n");

        }
    }
}