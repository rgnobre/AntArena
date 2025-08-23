using System.Drawing;

namespace AntArena.Domain.Interfaces
{
    public interface IAnt
    {
        void Move(Size bounds);
        void Draw(IRenderer renderer);
    }
}
