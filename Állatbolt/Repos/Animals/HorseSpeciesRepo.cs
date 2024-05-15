using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatboltProject.Repos
{
    public class HorseSpeciesRepo
    {
        private List<string> _horseSpecies { get; } = new() { "angol telivér", "arab telivér", "fríz", "hannoveri", "lipicai", "shire", "pinto", "curly", "connemara", "fjord", "clydesdale" };

        public List<string> FindAll()
        {
            return _horseSpecies;
        }

        public string FindFirst()
        {
            return FindAll().FirstOrDefault() ?? string.Empty;
        }
    }
}
