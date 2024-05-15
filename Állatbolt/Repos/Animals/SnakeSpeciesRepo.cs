using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatboltProject.Repos
{
    public class SnakeSpeciesRepo
    {
        private List<string> _snakeSpecies { get; } = new() { "óriáskígyó", "piton", "királysikló", "zöld fűsikló", "sikló" };

        public List<string> FindAll()
        {
            return _snakeSpecies;
        }

        public string FindFirst()
        {
            return FindAll().FirstOrDefault() ?? string.Empty;
        }
    }
}
