using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MG_58_2020
{
    public partial class MemoryGameForm
    {
        // Vraca apsolutnu putanju na osnovu relativne putanje
        public string RelativePath(string putanja)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDirectory, putanja);
        }

        // Racuna dimenzije polja
        public void CalculateFieldDimensions()
        {
            int screenWidth, screenHeight;
            screenWidth = this.ClientRectangle.Width;
            screenHeight = this.ClientRectangle.Height;

            this.fieldWidth = (int)Math.Round(1.0*(screenWidth - leftDistance - rightDistance - numberOfFieldsX * lineWidth) / numberOfFieldsX);
            this.fieldHeight = (int)Math.Round(1.0 * (screenHeight - topDistance - bottomDistance - numberOfFieldsY * lineWidth) / numberOfFieldsY);
        }

        public void LoadIcons()
        {
            icons = new List<Image>();
            foreach (string file in Directory.EnumerateFiles(RelativePath(Path.Combine(Program.ResourcesFolder, "icons")), "*.png"))
            {
                Image image = Image.FromFile(file);
                icons.Add(image);
            }
        }

        public List<Image> DivideImage(string fileName, int n, int m)
        {
            Image image = Image.FromFile(fileName);
            int width = image.Width / n;
            int height = image.Height / m;
            List<Image> parts = new List<Image>();
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Rectangle srcRect = new Rectangle(i * width, j * height, width, height);
                    Bitmap part = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(part);
                    g.DrawImage(image, new Rectangle(0, 0, width, height), srcRect, GraphicsUnit.Pixel);
                    parts.Add(part);
                }
            }
            return parts;
        }

        public void PlaySound()
        {
            SoundPlayer player = new SoundPlayer(RelativePath(Path.Combine(Program.ResourcesFolder, "click_effect.wav")));
            player.Play();
        }

        public Rectangle GetRectangle(int x,int y)
        {
            int startX = leftDistance+lineWidth + x * (fieldWidth );
            int startY = topDistance +lineWidth+ y * (fieldHeight );   
            return new Rectangle(startX,startY,fieldWidth-lineWidth,fieldHeight-lineWidth);
        }
    }
}