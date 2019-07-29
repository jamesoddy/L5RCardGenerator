using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace L5RCardGenerator.LayoutMaps
{
    public class AttachmentLayoutMap : LayoutMap
    {
        public Point FateCostLocation { get; set; }
        public Size FateCostSize { get; set; }
        public Point MilitaryBonusLocation { get; set; }
        public Size MilitaryBonusSize { get; set; }
        public Point PoliticalBonusLocation { get; set; }
        public Size PoliticalBonusSize { get; set; }
    }
}
