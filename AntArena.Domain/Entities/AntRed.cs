using AntArena.Domain.Enums;
using AntArena.Domain.Interfaces;
using System.Drawing;


namespace AntArena.Domain.Entities
{
    public class AntRed : Ant
    {
        public AntRed(Size borders, Random random, IAntMovement movement, Bitmap bitmap)
            : base(borders, "#FF0000", AntDirection.LeftUp, 6, 6, movement, random, bitmap) { }
    }
}
