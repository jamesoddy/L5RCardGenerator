using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace L5RCardGenerator.LayoutMaps
{
    public static class DefaultLayoutMaps
    {
        public static readonly CharacterLayoutMap CharacterLayoutMap =
            new CharacterLayoutMap()
            {
                ClanLocation = new Point(255, 4),
                ClanSize = new Size(40, 40),
                FateCostLocation = new Point(10, 8),
                FateCostSize = new Size(32, 32),
                GloryLocation = new Point(251, 245),
                GlorySize = new Size(29, 29),
                MilitarySkillLocation = new Point(12, 66),
                MilitarySkillSize = new Size(27, 31),
                PoliticalSkillLocation = new Point(12, 100),
                PoliticalSkillSize = new Size(27, 31),
                TextboxLocation = new Point(9, 289),
                TextboxSize = new Size(282, 107),
                TitleLocation = new Point(55, 10),
                TitleSize = new Size(193, 28),
                TraitsLocation = new Point(49, 271),
                TraitsSize = new Size(199, 14),
                TypeLocation = new Point(7, 46),
                TypeSize = new Size(44, 10)
            };
    }
}
