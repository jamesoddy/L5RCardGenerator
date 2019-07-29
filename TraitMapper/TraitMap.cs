using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace L5RCardGenerator.TraitMapper
{
    public static class TraitMap
    {
        private static IList<Trait> traits;
        private static IList<Trait> Traits
        {
            get
            {
                if (traits == null)
                {
                    var json = File.ReadAllText("traits.json");
                    traits = JsonConvert.DeserializeObject<IList<Trait>>(json);
                }
                return traits;
            }
        }
        public static string MapTraits(IEnumerable<string> cardDataTraits)
        {
            var matchingTraits = new List<Trait>();
            foreach (var traitId in cardDataTraits)
            {
                var trait = TraitMap.Traits.FirstOrDefault(t => t.Id == $"trait.{traitId}");
                if (trait != null)
                {
                    matchingTraits.Add(trait);
                } else
                {
                    throw new ArgumentException($"Cannot find \"{traitId}\" in list of traits");
                }
            }
            return string.Join(". ", matchingTraits.Select(t => t.Value));
        }
    }
}
