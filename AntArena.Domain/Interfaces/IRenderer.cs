using System.Drawing;

namespace AntArena.Domain.Interfaces
{
    public interface IRenderer
    {
        void SetGraphics(Graphics g);

        void DrawImage(Bitmap image, int x, int y, int width, int height);
    }
}