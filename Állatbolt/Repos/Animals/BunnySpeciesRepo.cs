using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatboltProject.Repos
{
    public class BunnySpeciesRepo
    {
        private List<string> _bunnySpecies { get; } = new() { "német óriás", "német kosorrú", "német tarka óriás", "német nagyezüst", "világos nagyezüst", "sallander", "nagy csincsilla", "mecklenburgi tarka", "holland nyúl" };

        public List<string> FindAll()
        {
            return _bunnySpecies;
        }

        public string FindFirst()
        {
            return FindAll().FirstOrDefault() ?? string.Empty;
        }
    }
}
