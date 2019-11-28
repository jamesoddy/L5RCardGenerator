using CoreHtmlToImage;
using L5RCardGenerator.LayoutMaps;
using L5RCardGenerator.ValueMaps;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace L5RCardGenerator
{
    static class CardHtmlGenerator
    {
        public static void GenerateCard(string outputPath)
        {
            var character1 = new CharacterCard();
            CharacterValueMap.UpdateCardFromJson(character1, SampleData.Character1);

            var sb = new StringBuilder();
            sb.Append("<html><head>");
            sb.Append($"<meta http-equiv=\"Content-type\" content=\"text/html;charset=utf-8\" /><meta charset=\"utf-8\" />");
            sb.Append($"<style>{File.ReadAllText("styles.css")}</style></head>");
            sb.Append("<body>");
            GenerateCharacterCardGraphics(sb, character1);
            sb.Append("</body></html>");

            var fileInfo = new FileInfo(outputPath);
            using (FileStream fs = new FileStream(fileInfo.FullName, FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.Write(sb.ToString());
                }
            }
            var converter = new HtmlConverter();
            var bytes = converter.FromHtmlString(sb.ToString(), 300);
            using (Image<Rgba32> image = Image.Load(bytes))
            {
                var ratio = (double)image.Height / image.Width;
                var width = 300;
                var height = (int)(ratio * 300);
                image.Mutate(x => x.Resize(width, height));
                image.Save("test.jpg");
            }
        }
        
        public static void GenerateCharacterCardGraphics(StringBuilder sb, CharacterCard card)
        {
            var layout = DefaultLayoutMaps.CharacterLayoutMap;
            sb.Append($"<div class=\"card\">");
            sb.Append(
                $"<img class=\"card__element card__clan\"" +
                $"style=\"margin-left: {layout.ClanLocation.X}px; margin-top: {layout.ClanLocation.Y}px; " +
                $"height: {layout.ClanSize.Height}px; width: {layout.ClanSize.Width}px;\" " +
                $"src=\"img\\{card.Clan}.png\">" +
                $"</img>"
                );
            sb.Append(
                $"<div class=\"card__element card__stat card__element--border-standard\"" +
                $"style=\"margin-left: {layout.FateCostLocation.X}px; margin-top: {layout.FateCostLocation.Y}px; " +
                $"height: {layout.FateCostSize.Height}px; width: {layout.FateCostSize.Width}px;\">" +
                $"{card.FateCost}" +
                $"</div>"
                );
            sb.Append(
                $"<div class=\"card__element card__stat card__element--border-standard\"" +
                $"style=\"margin-left: {layout.GloryLocation.X}px; margin-top: {layout.GloryLocation.Y}px; " +
                $"height: {layout.GlorySize.Height}px; width: {layout.GlorySize.Width}px;\">" +
                $"{card.Glory}" +
                $"</div>"
                );
            sb.Append(
                $"<div class=\"card__element card__stat card__element--border-standard card__element--color-red\"" +
                $"style=\"margin-left: {layout.MilitarySkillLocation.X}px; margin-top: {layout.MilitarySkillLocation.Y}px; " +
                $"height: {layout.MilitarySkillSize.Height}px; width: {layout.MilitarySkillSize.Width}px;\">" +
                $"{card.MilitarySkill}" +
                $"</div>"
                );
            sb.Append(
                $"<div class=\"card__element card__stat card__element--border-standard card__element--color-blue\"" +
                $"style=\"margin-left: {layout.PoliticalSkillLocation.X}px; margin-top: {layout.PoliticalSkillLocation.Y}px; " +
                $"height: {layout.PoliticalSkillSize.Height}px; width: {layout.PoliticalSkillSize.Width}px;\">" +
                $"{card.PoliticalSkill}" +
                $"</div>"
                );
            sb.Append(
                $"<div class=\"card__element card__textbox\"" +
                $"style=\"margin-left: {layout.TextboxLocation.X}px; margin-top: {layout.TextboxLocation.Y}px; " +
                $"height: {layout.TextboxSize.Height}px; width: {layout.TextboxSize.Width}px;\">" +
                $"<p>{Regex.Replace(card.Textbox, @"\r\n?|\n", "</p><p>")}</p>" +
                $"</div>"
                );
            sb.Append(
                $"<div class=\"card__element card__title card__element--border-standard\"" +
                $"style=\"margin-left: {layout.TitleLocation.X}px; margin-top: {layout.TitleLocation.Y}px; " +
                $"height: {layout.TitleSize.Height}px; width: {layout.TitleSize.Width}px;\">" +
                $"{card.Title}" +
                $"</div>"
                );
            sb.Append(
                $"<div class=\"card__element card__traits\"" +
                $"style=\"margin-left: {layout.TraitsLocation.X}px; margin-top: {layout.TraitsLocation.Y}px; " +
                $"height: {layout.TraitsSize.Height}px; width: {layout.TraitsSize.Width}px;\">" +
                $"{card.Traits}" +
                $"</div>"
                );
            sb.Append(
                $"<div class=\"card__element card__type\"" +
                $"style=\"margin-left: {layout.TypeLocation.X}px; margin-top: {layout.TypeLocation.Y}px; " +
                $"height: {layout.TypeSize.Height}px; width: {layout.TypeSize.Width}px;\">" +
                $"{card.Type}" +
                $"</div>"
                );
            sb.Append(@"</div>");
        }
    }
}
