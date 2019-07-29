using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace L5RCardGenerator.ValueMaps
{
    public static class CharacterValueMap
    {
        public static void UpdateCardFromJson(CharacterCard card, string json)
        {
            ValueMap.UpdateCardFromJson(card, json);
            var cardDatas = JsonConvert.DeserializeObject<CardData[]>(json);
            var cardData = cardDatas[0];

            card.FateCost = cardData.Cost.HasValue ? cardData.Cost.ToString() : "x";
            card.MilitarySkill = cardData.Military.HasValue ? cardData.Military.ToString() : "-";
            card.PoliticalSkill = cardData.Political.HasValue ? cardData.Political.ToString() : "-";
            card.Glory = cardData.Glory.HasValue ? cardData.Glory.ToString() : "x";
        }
    }
}
