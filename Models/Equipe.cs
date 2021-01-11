using System.Collections.Generic;
using EPlayers_AspNetCore.Interfaces;

namespace EPlayers_AspNetCore.Models
{
    public class Equipe : EplayersBase , IEquipe 
    {
        public int IdEquipe { get; set; }

        public string Nome { get; set; } 

        public string Imgem {get; set; }

        public const string PATH = "Database/Equipe.csv"; 

        public Equipe()
        {
             createFolderAndFile(PATH);
        }

        public void Create(Equipe e)
        {
           
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Equipe> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Equipe e)
        {
            throw new System.NotImplementedException();
        }
    } 
}