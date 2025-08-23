using AntArena.Domain.Entities;
using AntArena.Domain.Enums;
using AntArena.Domain.Interfaces;
using System.Drawing;

namespace AntArena.Infrastructure.Movements
{
    public class WhiteAntMovement : IAntMovement
    {
        public void Move(Ant ant, Size borders)
        {
            switch (ant.Direction)
            {
                case AntDirection.Left:
                    ant.X -= ant.HorizontalVelocity;
                    if (ant.X < 0)
                    {
                        ant.Direction = AntDirection.Right;
                    }
                    break;

                case AntDirection.Right:
                    ant.X += ant.HorizontalVelocity;
                    if (ant.X > borders.Width)
                    {
                        ant.Direction = AntDirection.Left;
                    }
                    break;
            }
        }
    }
}