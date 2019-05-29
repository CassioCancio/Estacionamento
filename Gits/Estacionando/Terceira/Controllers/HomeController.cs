using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Terceira.Models;
using Terceira;
using Terceira.Repositorios;
using Terceira.ViewModels;
using Microsoft.AspNetCore.Http;
using System;

namespace Terceira.Controllers
{
    public class HomeController : Controller
    {
        ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        RegistroRepositorio registroRepositorio = new RegistroRepositorio();
        public IActionResult Index()
        {
            var nomeModelo = modeloRepositorio.ListarModelo();
            var marca = marcaRepositorio.ListarMarca();

            Extracao extracao = new Extracao();
            extracao.Modelo = nomeModelo;
            extracao.Marca = marca;

            return View(extracao);
        }

        public IActionResult RegistrarEntrada(IFormCollection form)
        {
            System.Console.WriteLine(form["nome"]);
            System.Console.WriteLine(form["placa"]);
            System.Console.WriteLine(form["marca"]);
            System.Console.WriteLine(form["modelo"]);

            Registro registro = new Registro();
            registro.NomeUsuario = form["nome"];
            registro.Placa = form["placa"];
            registro.Marca = form["marca"];
            registro.NomeModelo = form["modelo"];
            registro.DataRegistro = DateTime.Now;

            registroRepositorio.Gravar(registro);
            
            return View("Sucesso");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
