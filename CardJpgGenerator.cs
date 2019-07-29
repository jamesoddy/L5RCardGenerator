using L5RCardGenerator.LayoutMaps;
using L5RCardGenerator.ValueMaps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Text;

namespace L5RCardGenerator
{
    static class CardJpgGenerator
    {
        public static void GenerateCard(string outputPath)
        {
            var character1 = new CharacterCard();
            CharacterValueMap.UpdateCardFromJson(character1, SampleData.Character1);
            var width = 300;
            var height = 419;
            using (var image = new Bitmap(width, height))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    graphics.TextContrast = 0;
                    graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    GenerateCharacterCardGraphics(graphics, character1);
                    image.Save(outputPath, ImageFormat.Png);
                }
            }
        }

        static readonly Brush DefaultBrush = Brushes.Black;
        static readonly Pen DefaultPen = new Pen(DefaultBrush, 2);

        static readonly Font DefaultStatFont = new Font("Arial", 16);
        static readonly Font DefaultTextboxFont = new Font("Arial", 8);
        static readonly Font DefaultTitleFont = new Font("Arial", 10);
        static readonly Font DefaultTraitsFont = new Font("Arial", 5, FontStyle.Bold);
        static readonly Font DefaultTypeFont = new Font("Arial", 5);

        
        static readonly StringFormat DefaultStatFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        static readonly StringFormat DefaultTextboxFormat = new StringFormat()
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Near
        };
        static readonly StringFormat DefaultTitleFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        static readonly StringFormat DefaultTraitsFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        static readonly StringFormat DefaultTypeFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        public static void GenerateCharacterCardGraphics(Graphics graphics, CharacterCard card)
        {
            var layout = DefaultLayoutMaps.CharacterLayoutMap;
            var brush = DefaultBrush;
            var pen = DefaultPen;

            graphics.FillRectangle(brush, new Rectangle(layout.ClanLocation, layout.ClanSize));

            var fateRect = new Rectangle(layout.FateCostLocation, layout.FateCostSize);
            graphics.DrawRectangle(pen, fateRect);
            graphics.DrawString(card.FateCost, DefaultStatFont, brush, fateRect, DefaultStatFormat);

            var gloryRect = new Rectangle(layout.GloryLocation, layout.GlorySize);
            graphics.DrawRectangle(pen, gloryRect);
            graphics.DrawString(card.Glory, DefaultStatFont, brush, gloryRect, DefaultStatFormat);

            var militarySkillRect = new Rectangle(layout.MilitarySkillLocation, layout.MilitarySkillSize);
            graphics.DrawRectangle(pen, militarySkillRect);
            graphics.DrawString(card.MilitarySkill, DefaultStatFont, brush, militarySkillRect, DefaultStatFormat);

            var politicalSkillRect = new Rectangle(layout.PoliticalSkillLocation, layout.PoliticalSkillSize);
            graphics.DrawRectangle(pen, politicalSkillRect);
            graphics.DrawString(card.PoliticalSkill, DefaultStatFont, brush, politicalSkillRect, DefaultStatFormat);

            var textboxRect = new Rectangle(layout.TextboxLocation, layout.TextboxSize);
            graphics.DrawString(card.Textbox, DefaultTextboxFont, brush, textboxRect, DefaultTextboxFormat);;

            var titleRect = new Rectangle(layout.TitleLocation, layout.TitleSize);
            graphics.DrawRectangle(pen, titleRect);
            graphics.DrawString(card.Title, DefaultTitleFont, brush, titleRect, DefaultTitleFormat);

            var traitsRect = new Rectangle(layout.TraitsLocation, layout.TraitsSize);
            graphics.DrawString(card.Traits, DefaultTraitsFont, brush, traitsRect, DefaultTraitsFormat);
            
            var typeRect = new Rectangle(layout.TypeLocation, layout.TypeSize);
            graphics.DrawString(card.Type, DefaultTypeFont, brush, typeRect, DefaultTypeFormat);
        }
    }
}
