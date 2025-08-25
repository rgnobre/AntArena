using AntArena.Domain.Enums;
using AntArena.Domain.Extensions;
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
            AntImage = image.ReplaceColor(colorHex);
            this.movement = movement;

            X = random.Next(0, borders.Width);
            Y = random.Next(0, borders.Height);
        }

        public void Move(Size bounds) => movement.Move(this, bounds);

        public void Draw(IRenderer renderer) => renderer.DrawImage(AntImage, X, Y, 32, 36);
    }
}