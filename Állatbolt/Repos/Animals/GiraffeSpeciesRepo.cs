using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatboltProject.Repos
{
    public class GiraffeSpeciesRepo
    {
        private List<string> _giraffeSpecies { get; } = new() { "déli zsiráf", "maszáj zsiráf", "kockás zsiráf", "északi zsiráf" };

        public List<string> FindAll()
        {
            return _giraffeSpecies;
        }

        public string FindFirst()
        {
            return FindAll().FirstOrDefault() ?? string.Empty;
        }
    }
}
