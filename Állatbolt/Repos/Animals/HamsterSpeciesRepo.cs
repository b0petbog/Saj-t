using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatboltProject.Repos
{
    public class HamsterSpeciesRepo
    {
        private List<String> _hamsterSpecies = new() { "szíriai aranyhörcsög", "campbell törpehörcsög", "dzsungáriai törpehörcsög", "kínai csíkos törpehörcsög", "roborovszki törpehörcsög" };

        public List<string> FindAll()
        {
            return _hamsterSpecies;
        }

        public string FindFirst()
        {
            return FindAll().FirstOrDefault() ?? string.Empty;
        }
    }
}
