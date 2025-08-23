using AntArena.Domain.Interfaces;
using System.Drawing;

namespace AntArena.Infrastructure.Renderers
{
    public class Renderer : IRenderer
    {
        private Graphics _graphics;

        public void SetGraphics(Graphics g) => _graphics = g;

        public void DrawImage(Bitmap image, int x, int y, int width, int height)
        {
            _graphics.DrawImage(image, x, y, width, height);
        }
    }
}
