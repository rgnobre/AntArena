using AntArena.Domain.Enums;
using AntArena.Domain.Interfaces;
using System.Drawing;

namespace AntArena.Domain.Entities
{
    public abstract class Ant : IAnt
    {
        public int X { get; set; }
        public int Y { get; set; }
        public AntDirection Direction { get; set; }
        public int VerticalVelocity { get; set; }
        public int HorizontalVelocity { get; set; }

        private readonly IAntMovement movement;
        public Bitmap AntImage { get; private set; }

        protected Ant(Size borders,
            string colorHex,
            AntDirection initialDirection,
            int horizontalVelocity,
            int verticalVelocity,
            IAntMovement movement,
            Random random,
            Bitmap image)
        {
            Direction = initialDirection;
            VerticalVelocity = verticalVelocity;
            HorizontalVelocity = horizontalVelocity;
            AntImage = ColorAnt(image, colorHex);
            this.movement = movement;

            X = random.Next(0, borders.Width);
            Y = random.Next(0, borders.Height);
        }

        private static Bitmap ColorAnt(Bitmap original, string colorHex)
        {
            Color newColor = ColorTranslator.FromHtml(colorHex);
            Color white = ColorTranslator.FromHtml("#FFFFFF");

            Bitmap bmp = new Bitmap(original);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color gotColor = bmp.GetPixel(x, y);
                    if (gotColor == white)
                        bmp.SetPixel(x, y, newColor);
                }
            }
            return bmp;
        }

        public void Move(Size bounds) => movement.Move(this, bounds);

        public void Draw(IRenderer renderer) => renderer.DrawImage(AntImage, X, Y, 32, 36);
    }
}