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
          
    }
}