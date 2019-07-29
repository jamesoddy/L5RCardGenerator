using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace L5RCardGenerator.LayoutMaps
{
    public class StrongholdLayoutMap : LayoutMap
    {
        public Point StrengthBonusLocation { get; set; }
        public Size StrengthBonusSize { get; set; }
        public Point HonorLocation { get; set; }
        public Size HonorSize { get; set; }
        public Point FateLocation { get; set; }
        public Size FateSize { get; set; }
        public Point InfluenceLocation { get; set; }
        public Size InfluenceSize { get; set; }
    }
}
