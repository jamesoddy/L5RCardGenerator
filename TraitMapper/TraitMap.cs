using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using L5RCardGenerator.Labels;

namespace L5RCardGenerator.TraitMapper
{
    public static class TraitMap
    {
        public static string MapTraits(IEnumerable<string> cardDataTraits)
        {
            var matchingLabels = new List<Label>();
            foreach (var traitId in cardDataTraits)
            {
                var trait = LabelService.Labels.FirstOrDefault(t => t.Id == $"trait.{traitId}");
                if (trait != null)
                {
                    matchingLabels.Add(trait);
                }
                else
                {
                    throw new ArgumentException($"Cannot find \"{traitId}\" in list of traits");
                }
            }
            return string.Join(". ", matchingLabels.Select(t => t.Value));
        }
    }
}
