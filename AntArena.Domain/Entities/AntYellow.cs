using AntArena.Domain.Enums;
using AntArena.Domain.Interfaces;
using System.Drawing;

namespace AntArena.Domain.Entities
{
    public class AntYellow : Ant
    {
        public AntYellow(Size borders, Random random, IAntMovement movement, Bitmap bitmap)
            : base(borders, "#FFFF00", AntDirection.RightDown, 4, 4, movement, random, bitmap) { }
    }
}