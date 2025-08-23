using AntArena.Domain.Enums;

namespace AntArena.Domain.Interfaces
{
    public interface IAntFactory
    {
        IAnt Create(AntType type);
    }
}