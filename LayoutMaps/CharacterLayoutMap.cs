using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace L5RCardGenerator.LayoutMaps
{
    public class CharacterLayoutMap : LayoutMap
    {
        public Point FateCostLocation { get; set; }
        public Size FateCostSize { get; set; }
        public Point MilitarySkillLocation { get; set; }
        public Size MilitarySkillSize { get; set; }
        public Point PoliticalSkillLocation { get; set; }
        public Size PoliticalSkillSize { get; set; }
        public Point GloryLocation { get; set; }
        public Size GlorySize { get; set; }
    }
}
