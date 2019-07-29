using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace L5RCardGenerator.Labels
{
    public static class LabelService
    {
        private static IList<Label> labels;
        public static IList<Label> Labels
        {
            get
            {
                if (labels == null)
                {
                    var json = File.ReadAllText(@"json\labels.json");
                    labels = JsonConvert.DeserializeObject<IList<Label>>(json);
                }
                return labels;
            }
        }
    }
}
