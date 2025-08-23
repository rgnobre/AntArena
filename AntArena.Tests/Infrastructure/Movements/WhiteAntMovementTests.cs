using AntArena.Domain.Entities;
using AntArena.Domain.Enums;
using AntArena.Infrastructure.Movements;
using System.Drawing;

namespace AntArena.Tests.Infrastructure.Movements
{
    public class WhiteAntMovementTests
    {
        private readonly WhiteAntMovement _whiteAntMovement;
        private readonly Size _arenaSize;
        private readonly Random _random;
        private readonly Bitmap _bitmap;

        public WhiteAntMovementTests()
        {
            _whiteAntMovement = new WhiteAntMovement();
            _arenaSize = new Size(100, 100);
            _random = new Random();
            _bitmap = new Bitmap(10, 10);
        }

        [Fact]
        public void Move_LeftOutOfBoundsX_ChangesDirectionToRight()
        {
            // Arrange
            var ant = new AntWhite(_arenaSize, _random, _whiteAntMovement, _bitmap)
            {
                X = -1,
                Y = 50,
                Direction = AntDirection.Left,
                HorizontalVelocity = 5
            };

            // Act
            _whiteAntMovement.Move(ant, _arenaSize);

            // Assert
            Assert.Equal(AntDirection.Right, ant.Direction);
        }

        [Fact]
        public void Move_RightOutOfBoundsX_ChangesDirectionToLeft()
        {
            // Arrange
            var ant = new AntWhite(_arenaSize, _random, _whiteAntMovement, _bitmap)
            {
                X = 101,
                Y = 50,
                Direction = AntDirection.Right,
                HorizontalVelocity = 5
            };

            // Act
            _whiteAntMovement.Move(ant, _arenaSize);

            // Assert
            Assert.Equal(AntDirection.Left, ant.Direction);
        }

        [Fact]
        public void Move_LeftWithinBounds_UpdatesPositionCorrectly()
        {
            // Arrange
            var ant = new AntWhite(_arenaSize, _random, _whiteAntMovement, _bitmap)
            {
                X = 50,
                Y = 50,
                Direction = AntDirection.Left,
                HorizontalVelocity = 5
            };

            // Act
            _whiteAntMovement.Move(ant, _arenaSize);

            // Assert
            Assert.Equal(45, ant.X);
            Assert.Equal(AntDirection.Left, ant.Direction);
        }

        [Fact]
        public void Move_RightWithinBounds_UpdatesPositionCorrectly()
        {
            // Arrange
            var ant = new AntWhite(_arenaSize, _random, _whiteAntMovement, _bitmap)
            {
                X = 50,
                Y = 50,
                Direction = AntDirection.Right,
                HorizontalVelocity = 5
            };

            // Act
            _whiteAntMovement.Move(ant, _arenaSize);

            // Assert
            Assert.Equal(55, ant.X);
            Assert.Equal(AntDirection.Right, ant.Direction);
        }
    }
}