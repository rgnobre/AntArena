using System.Drawing;

namespace AntArena.Domain.Interfaces
{
    public interface IArenaSimulation
    {
        void InitializeAnts(int antQuantity);
        void Update(Size bounds);
        void Render(IRenderer renderer);
    }
}