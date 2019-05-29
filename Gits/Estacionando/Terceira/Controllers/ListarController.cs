using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Terceira.Models;
using Terceira.Repositorios;
using Terceira.ViewModels;

namespace Terceira.Controllers
{
    public class ListarController : Controller
    {
        ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        RegistroRepositorio registroRepositorio = new RegistroRepositorio();
        private List<Registro> registros = new List<Registro> ();
        private List<Registro> registrosRecuperados = new List<Registro> ();
        public IActionResult Index()
        {
            var nomeModelo = modeloRepositorio.ListarModelo();
            var marca = marcaRepositorio.ListarMarca();

            Extracao extracao = new Extracao();
            extracao.Modelo = nomeModelo;
            extracao.Marca = marca;
            
            return View(extracao);
        }


        public IActionResult NomeMotorista(IFormCollection form)
        {
            System.Console.WriteLine(form["nome"]);

            registros = registroRepositorio.Listar();

            foreach (var item in registros) {
                if(item.NomeUsuario.Equals(form["nome"])){
                    registrosRecuperados.Add (item);
                }
            }
            
            var extracao = new Extracao();

            extracao.Registros = registrosRecuperados;

            return View(extracao);
        }
        public IActionResult PlacaCarro(IFormCollection form)
        {

            System.Console.WriteLine(form["placa"]);

            registros = registroRepositorio.Listar();

            foreach (var item in registros) {
                if(item.Placa.Equals(form["placa"])){
                    registrosRecuperados.Add (item);
                }
            }
            
            var extracao = new Extracao();

            extracao.Registros = registrosRecuperados;

            return View(extracao);
        }
        public IActionResult Marca(IFormCollection form)
        {
            
            System.Console.WriteLine(form["marca"]);

            registros = registroRepositorio.Listar();

            foreach (var item in registros) {
                if(item.Marca.Equals(form["marca"])){
                    registrosRecuperados.Add (item);
                }
            }
            
            var extracao = new Extracao();

            extracao.Registros = registrosRecuperados;

            return View(extracao);
        }
        public IActionResult Modelo(IFormCollection form)
        {
            
            System.Console.WriteLine(form["modelo"]);

            registros = registroRepositorio.Listar();

            foreach (var item in registros) {
                if(item.NomeModelo.Equals(form["modelo"])){
                    registrosRecuperados.Add (item);
                }
            }
            
            var extracao = new Extracao();

            extracao.Registros = registrosRecuperados;

            return View(extracao);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
