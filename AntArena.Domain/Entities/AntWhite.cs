using AntArena.Domain.Enums;
using AntArena.Domain.Interfaces;
using System.Drawing;


namespace AntArena.Domain.Entities
{
    public class AntWhite : Ant
    {
        public AntWhite(Size borders, Random random, IAntMovement movement, Bitmap bitmap)
            : base(borders, "#FFFAFA", AntDirection.Left, 10, 10, movement, random, bitmap) { }
    }
}
