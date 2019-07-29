using Newtonsoft.Json;
using L5RCardGenerator.TraitMapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace L5RCardGenerator.ValueMaps
{
    public static class ValueMap
    {
        public static void UpdateCardFromJson(Card card, string json)
        {
            var cardDatas = JsonConvert.DeserializeObject<CardData[]>(json);
            var cardData = cardDatas[0];

            const char unicityChar = '\u235f';

            card.Clan = cardData.Clan;
            card.Textbox = cardData.Text;
            card.Title = $"{(cardData.Unicity ? unicityChar : char.MinValue )} {cardData.Name}";
            card.Traits = TraitMap.MapTraits(cardData.Traits);
            card.Type = cardData.Type;
        }
}
}
