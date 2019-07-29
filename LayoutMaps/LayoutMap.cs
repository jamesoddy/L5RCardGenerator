using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace L5RCardGenerator.LayoutMaps
{
    public class LayoutMap
    {
        public Point TitleLocation { get; set; }
        public Size TitleSize { get; set; }
        public Point ClanLocation { get; set; }
        public Size ClanSize { get; set; }
        public Point TypeLocation { get; set; }
        public Size TypeSize { get; set; }
        public Point TraitsLocation { get; set; }
        public Size TraitsSize { get; set; }
        public Point TextboxLocation { get; set; }
        public Size TextboxSize { get; set; }
    }
}
