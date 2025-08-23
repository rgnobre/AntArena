using AntArena.Domain.Enums;
using AntArena.Domain.Interfaces;
using System.Drawing;

namespace AntArena.Domain.Entities
{
    public class AntBlack : Ant
    {
        public AntBlack(Size borders, Random random, IAntMovement movement, Bitmap bitmap)
           : base(borders, "#000000", AntDirection.RightUp, 2, 6, movement, random, bitmap) { }
    }
}