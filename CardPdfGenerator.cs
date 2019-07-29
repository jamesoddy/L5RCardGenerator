using L5RCardGenerator.LayoutMaps;
using L5RCardGenerator.ValueMaps;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Text;

namespace L5RCardGenerator
{
    static class CardPdfGenerator
    {
        public static void GenerateCard(string outputPath)
        {
            var character1 = new CharacterCard();
            CharacterValueMap.UpdateCardFromJson(character1, SampleData.Character1);
            var width = 300;
            var height = 419;

            var document = new PdfDocument();
            var page = document.AddPage();
            page.Width = width;
            page.Height = height;
            
            var graphics = XGraphics.FromPdfPage(page);

            GenerateCharacterCardGraphics(graphics, character1);

            var fileInfo = new FileInfo(outputPath);
            document.Save(fileInfo.FullName);
        }

        static readonly XColor DefaultColor = XColors.Black;
        static readonly XBrush DefaultBrush = new XSolidBrush(DefaultColor);
        static readonly XPen DefaultPen = new XPen(DefaultColor, 2);

        static readonly XPdfFontOptions DefaultFontOptions = new XPdfFontOptions(PdfFontEncoding.Unicode);
        static readonly XFont DefaultStatFont = new XFont("Arial", 16, XFontStyle.Regular, DefaultFontOptions);
        static readonly XFont DefaultTextboxFont = new XFont("Arial", 10, XFontStyle.Regular, DefaultFontOptions);
        static readonly XFont DefaultTitleFont = new XFont("Arial", 12, XFontStyle.Regular, DefaultFontOptions);
        static readonly XFont DefaultTraitsFont = new XFont("Arial", 8, XFontStyle.Bold, DefaultFontOptions);
        static readonly XFont DefaultTypeFont = new XFont("Arial", 6, XFontStyle.Regular, DefaultFontOptions);
        
        public static void GenerateCharacterCardGraphics(XGraphics graphics, CharacterCard card)
        {
            XTextFormatter tf = new XTextFormatter(graphics);
            var layout = DefaultLayoutMaps.CharacterLayoutMap;

            var clanRect = new XRect(layout.ClanLocation.X, layout.ClanLocation.Y, layout.ClanSize.Width, layout.ClanSize.Height);
            graphics.DrawRectangle(DefaultBrush, clanRect);

            var fateRect = new XRect(layout.FateCostLocation.X, layout.FateCostLocation.Y, layout.FateCostSize.Width, layout.FateCostSize.Height);
            graphics.DrawRectangle(DefaultPen, fateRect);
            graphics.DrawString(card.FateCost, DefaultStatFont, DefaultBrush, fateRect, XStringFormats.Center);

            var gloryRect = new XRect(layout.GloryLocation.X, layout.GloryLocation.Y, layout.GlorySize.Width, layout.GlorySize.Height);
            graphics.DrawRectangle(DefaultPen, gloryRect);
            graphics.DrawString(card.Glory, DefaultStatFont, DefaultBrush, gloryRect, XStringFormats.Center);

            var militarySkillRect = new XRect(layout.MilitarySkillLocation.X, layout.MilitarySkillLocation.Y, layout.MilitarySkillSize.Width, layout.MilitarySkillSize.Height);
            graphics.DrawRectangle(DefaultPen, militarySkillRect);
            graphics.DrawString(card.MilitarySkill, DefaultStatFont, DefaultBrush, militarySkillRect, XStringFormats.Center);

            var politicalSkillRect = new XRect(layout.PoliticalSkillLocation.X, layout.PoliticalSkillLocation.Y, layout.PoliticalSkillSize.Width, layout.PoliticalSkillSize.Height);
            graphics.DrawRectangle(DefaultPen, politicalSkillRect);
            graphics.DrawString(card.PoliticalSkill, DefaultStatFont, DefaultBrush, politicalSkillRect, XStringFormats.Center);

            var textboxRect = new XRect(layout.TextboxLocation.X, layout.TextboxLocation.Y, layout.TextboxSize.Width, layout.TextboxSize.Height);
            tf.DrawString(card.Textbox, DefaultTextboxFont, DefaultBrush, textboxRect, XStringFormats.TopLeft);

            var titleRect = new XRect(layout.TitleLocation.X, layout.TitleLocation.Y, layout.TitleSize.Width, layout.TitleSize.Height);
            graphics.DrawRectangle(DefaultPen, titleRect);
            graphics.DrawString(card.Title, DefaultTitleFont, DefaultBrush, titleRect, XStringFormats.Center);

            var traitsRect = new XRect(layout.TraitsLocation.X, layout.TraitsLocation.Y, layout.TraitsSize.Width, layout.TraitsSize.Height);
            graphics.DrawString(card.Traits, DefaultTraitsFont, DefaultBrush, traitsRect, XStringFormats.Center);

            var typeRect = new XRect(layout.TypeLocation.X, layout.TypeLocation.Y, layout.TypeSize.Width, layout.TypeSize.Height);
            graphics.DrawString(card.Type, DefaultTypeFont, DefaultBrush, typeRect, XStringFormats.Center);
        }
    }
}
