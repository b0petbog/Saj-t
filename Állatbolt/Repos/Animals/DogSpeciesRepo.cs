using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatboltProject.Repos
{
    public class DogSpeciesRepo
    {
        public List<string> _dogSpecies { get; } = new() { "németjuhász", "husky", "bulldog", "bison", "labrador", "golden retriever", "beagle", "tacskó", "alaszkai malamut", "pudli", "chihuahua", "border collie", "rottweiler", "yorki", "dobermann", "jack russel", "dalmata", "agár" };

        public List<string> FindAll()
        {
            return _dogSpecies;
        }

        public string FindFirst()
        {
            return FindAll().FirstOrDefault() ?? string.Empty;
        }
    }
}
