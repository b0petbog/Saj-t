using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatboltProject.Repos
{
    public class CatSpeciesRepo
    {
        private List<string> _catSpecies { get; } = new() { "bengáli", "balinéz", "bombay", "burmai szent templommacska", "cornish rex", "egyiptomi mau", "himalája macska", "orosz kék", "perzsa", "szfinx", "sziámi" };

        public List<string> FindAll()
        {
            return _catSpecies;
        }

        public string FindFirst()
        {
            return FindAll().FirstOrDefault() ?? string.Empty;
        }
    }
}
