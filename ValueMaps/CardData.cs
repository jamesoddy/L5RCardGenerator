using System;
using System.Collections.Generic;
using System.Text;

namespace L5RCardGenerator.ValueMaps
{
    public class CardData
    {
        public ICollection<string> AllowedClans { get; set; }
        public string Clan { get; set; }
        public int? Cost { get; set; }
        public int? DeckLimit { get; set; }
        public string Element { get; set; }
        public int? Fate { get; set; }
        public int? Glory { get; set; }
        public int? Honor { get; set; }
        public string Id { get; set; }
        public int? InfluenceCost { get; set; }
        public int? influencePool { get; set; }
        public bool IsRestricted { get; set; }
        public int? Military { get; set; }
        public string MilitaryBonus { get; set; }
        public string Name { get; set; }
        public string NameExtra { get; set; }
        public int? Political { get; set; }
        public string PoliticalBonus { get; set; }
        public string RoleRestriction { get; set; }
        public string Side { get; set; }
        public string Strength { get; set; }
        public string StrengthBonus { get; set; }
        public string Text { get; set; }
        public ICollection<string> Traits { get; set; }
        public string Type { get; set; }
        public bool Unicity { get; set; }
    }
}
