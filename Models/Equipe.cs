using System.Collections.Generic;
using System.IO;
using EPlayers_AspNetCore.Interfaces;

namespace EPlayers_AspNetCore.Models
{
    public class Equipe : EplayersBase , IEquipe 
    {
        public int IdEquipe { get; set; }

        public string Nome { get; set; } 

        public string Imgem {get; set; }
        public string Imagem { get; internal set; }

        public const string PATH = "Database/Equipe.csv"; 

        public Equipe()
        {
             createFolderAndFile(PATH);
        }

           // Criamos o método para preparar a linha do CSV
           public string Prepare(Equipe e)

           {
               return $"{e.IdEquipe}{e.Nome};{e.Imgem}"; 
           }
          
        public void Create(Equipe e)
        {
            // Peparamos um arry de string para o método AppendAllLines 
             string[] linhas = { Prepare (e)};  
      // Acresentamos a nova linha 
             File.AppendAllLines( PATH, linhas  );   
        }

        public void Delete(int id)
        {

            List<string> linhas = ReaAllLinesCSV(PATH);

            // 2; SNk;snk.jpg
             // Removemos as linhas com o códio comparado
             // ToString  -> converte para texto (string)
             linhas.RemoveAll( x => x.Split(";")[0] == id.ToString());

      

          //  Reescrever o csv com a lista alterada
             RewriteCSV (PATH, linhas);


        }

        public List<Equipe> ReadAll()
        {
            List <Equipe> equipes = new List<Equipe>(); 
      // Lemos todas as linhas do CSV 
                  string[] linhas = File.ReadAllLines(PATH); 
        
                foreach(string item in linhas )
                {
                    // 1; VivoKyd;vivo;jpg
                    // [0] = 1 
                    // [1] = Vivo Keyd
                    // [2] = vivo jpg 
                    string[] linha = item.Split(";");

                    Equipe novaEquipe = new Equipe();
                    novaEquipe.IdEquipe = int.Parse (linha [0] );
                    novaEquipe.Nome = linha [1];
                    novaEquipe.Imgem = linha [2];

                    equipes.Add(novaEquipe);
                }

            return equipes; 
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReaAllLinesCSV(PATH);

            // 2; SNk;snk.jpg
             // Removemos as linhas com o códio comparado
             linhas.RemoveAll( x => x.Split(";")[0] == e.IdEquipe.ToString ());

             // Adicionamos na lista a equipe alterada
             linhas.Add(Prepare (e));

          //  Reescrever o csv com a lista alterada
             RewriteCSV (PATH, linhas);

        }
    } 
}