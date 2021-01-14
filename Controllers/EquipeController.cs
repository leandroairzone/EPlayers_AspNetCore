using System;
using System.IO;
using EPlayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_AspNetCore.Controllers
{
    [Route("Equipe")]
    // http://localhost:5000/Equipe
    public class EquipeController : Controller

    {
        
        // Criamos uma Instáncia de equipe model
        Equipe equipeModel = new Equipe();
     
     // http://localhost:5000/Equipe/Listar
        [Route("Listar")]
   public IActionResult Index ()

   {
       // Listamos todas as equipes e enviamos para a View, através da ViewBag
        ViewBag.Equipes = equipeModel.ReadAll();
       return View();
   }
             // http://localhost:5000/Equipe/Cadastrar
       [Route("Cadastrar")]
             public IActionResult Cadastrar(IFormCollection form)
            {
                      Equipe novaEquipe  = new Equipe();
                      novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"] );
                      novaEquipe.Nome     = form["Nome"];

                     // Upload Início
                         
                         // Verificamos se o usúario selecionou um arquivo 
                     if(form.Files.Count > 0 )

                    {
                         // Recebemos o arquivo que o usúario enviou e armazenamos na variável file 
                        var file = form.Files [0];
                        var folder = Path.Combine( Directory.GetCurrentDirectory (), "wwwroot/img/Equipe");

                           // Verificamos se o diretório (pasta) já existe 
                           //  se não, a criamos 
                        if(!Directory.Exists( folder))

                        {
                            Directory.CreateDirectory(folder);
                        }
  

                                    // Localhost:5001                                       Equipe  Imagem.jpg
                           var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/", folder, file.FileName);

                          using( var stream = new FileStream(path, FileMode.Create))
                       {
                           file.CopyTo(stream);
                       }

                          novaEquipe.Imagem = file.FileName;

                         }
                          else   
                          {
                                   novaEquipe.Imagem = "padrão.png";
                          }

                        


                     // Upload Final 

                  // Chamamos o método Create para salvar a novaEquipe no CSV
                      equipeModel.Create(novaEquipe);
                      // Atualizei   a lista de equipes na View 
                      ViewBag.Equipes = equipeModel.ReadAll();

                      return LocalRedirect("~/Equipe/Listar");
            }

                  
                        // http://localhost:5000/Equipe/1            
                     
                     [Route("{id}")]

                     public IActionResult Excluir (int id)

                     {
                         equipeModel.Delete(id);
                         ViewBag.Equipes = equipeModel.ReadAll();

                           return LocalRedirect("~/Equipe/Lista");
                      }
                  }
                }