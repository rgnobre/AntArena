using AntArena.Domain.Entities;
using AntArena.Domain.Enums;
using AntArena.Domain.Interfaces;
using System.Drawing;

namespace AntArena.Infrastructure.Movements
{
    public class BlackAntMovement : IAntMovement
    {
        public void Move(Ant ant, Size borders)
        {
            {
                switch (ant.Direction)
                {
                    case AntDirection.LeftUp:
                        ant.X -= ant.HorizontalVelocity;
                        ant.Y -= ant.VerticalVelocity;

                        if (ant.X < 0 && ant.Y < 500)
                        {
                            ant.Direction = AntDirection.RightDown;
                        }
                        else if (ant.X < 0)
                        {
                            ant.Direction = AntDirection.RightUp;
                        }
                        else if (ant.Y < 500)
                        {
                            ant.Direction = AntDirection.LeftDown;
                        }
                        break;

                    case AntDirection.LeftDown:
                        ant.X -= ant.HorizontalVelocity;
                        ant.Y += ant.VerticalVelocity;

                        if (ant.X < 0 && ant.Y > borders.Height)
                        {
                            ant.Direction = AntDirection.RightUp;
                        }
                        else if (ant.X < 0)
                        {
                            ant.Direction = AntDirection.RightDown;
                        }
                        else if (ant.Y > borders.Height)
                        {
                            ant.Direction = AntDirection.LeftUp;
                        }
                        break;

                    case AntDirection.RightUp:
                        ant.X += ant.HorizontalVelocity;
                        ant.Y -= ant.VerticalVelocity;

                        if (ant.X > borders.Width && ant.Y < 500)
                        {
                            ant.Direction = AntDirection.LeftDown;
                        }
                        else if (ant.X > borders.Width)
                        {
                            ant.Direction = AntDirection.LeftUp;
                        }
                        else if (ant.Y < 500)
                        {
                            ant.Direction = AntDirection.RightDown;
                        }
                        break;

                    case AntDirection.RightDown:
                        ant.X += ant.HorizontalVelocity;
                        ant.Y += ant.VerticalVelocity;

                        if (ant.X > borders.Width && ant.Y > borders.Height)
                        {
                            ant.Direction = AntDirection.LeftUp;
                        }
                        else if (ant.X > borders.Width)
                        {
                            ant.Direction = AntDirection.LeftDown;
                        }
                        else if (ant.Y > borders.Height)
                        {
                            ant.Direction = AntDirection.RightUp;
                        }
                        break;
                }
            }
        }
    }
}