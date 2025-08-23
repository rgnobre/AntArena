using AntArena.Domain.Entities;
using System.Drawing;

namespace AntArena.Domain.Interfaces
{
    public interface IAntMovement
    {
        void Move(Ant ant, Size bounds);
    }
}