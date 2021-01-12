using System.Collections.Generic;
using System.IO;

namespace EPlayers_AspNetCore.Models
{
    public class EplayersBase
    {
          public void createFolderAndFile(string _path)
          
          {
              // DataBase/Equipe.cs 
                string folder =_path.Split("/")[0];
               
                if(!Directory.Exists(folder))

                {
                    Directory.CreateDirectory(folder);

                }
               
                if(! File.Exists(_path))

                {
                    File.Create(_path); 
                }
          }

         public  List<string> ReaAllLinesCSV(string path)

         {
              List<string>  linhas = new List<string>();

             // using  --> Responsável por abrir e fechar o arquivo automaticamente
             // StreamReader ->  Ler os dados de um arquivo 
              using( StreamReader file = new StreamReader (path))

              {
                  
               string linha; 

                  // Percorre as linhas com um laço while
                  while((linha = file.ReadLine()) != null)

                  {
                      linhas.Add(linha);
                  }                
              }

              return linhas;
              }

              public void RewriteCSV(string path, List<string> linhas )

              {
        
                  // StreamWrite escrever dados em um arquivo
                  using(StreamReader output = new StreamReader(path))
                
                        {
                            foreach (var item in linhas)

                            {
                                output.Write(item + '\n');
                            }
                        }
               
              }
    }
}