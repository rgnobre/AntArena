using AntArena.Domain.Entities;
using AntArena.Domain.Enums;
using AntArena.Infrastructure.Movements;
using System.Drawing;

namespace AntArena.Tests.Infrastructure.Movements
{
    public class BlackAntMovementTests
    {
        private readonly BlackAntMovement _blackAntMovement;
        private readonly Size _arenaSize;
        private readonly Random _random;
        private readonly Bitmap _bitmap;

        public BlackAntMovementTests()
        {
            _blackAntMovement = new BlackAntMovement();
            _arenaSize = new Size(100, 100);
            _random = new Random();
            _bitmap = new Bitmap(10, 10);
        }

        [Fact]
        public void Move_LeftUpOutOfBoundsXAndY_ChangesDirectionToRightDown()
        {
            // Arrange
            var ant = new AntBlack(_arenaSize, _random, _blackAntMovement, _bitmap)
            {
                X = -1,
                Y = 499,
                Direction = AntDirection.LeftUp,
                HorizontalVelocity = 1,
                VerticalVelocity = 1
            };

            // Act
            _blackAntMovement.Move(ant, _arenaSize);

            // Assert
            Assert.Equal(AntDirection.RightDown, ant.Direction);
        }

        [Fact]
        public void Move_LeftDownOutOfBoundsXAndY_ChangesDirectionToRightUp()
        {
            // Arrange
            var ant = new AntBlack(_arenaSize, _random, _blackAntMovement, _bitmap)
            {
                X = -1,
                Y = 101,
                Direction = AntDirection.LeftDown,
                HorizontalVelocity = 1,
                VerticalVelocity = 1
            };

            // Act
            _blackAntMovement.Move(ant, _arenaSize);

            // Assert
            Assert.Equal(AntDirection.RightUp, ant.Direction);
        }

        [Fact]
        public void Move_RightUpOutOfBoundsXAndY_ChangesDirectionToLeftDown()
        {
            // Arrange
            var ant = new AntBlack(_arenaSize, _random, _blackAntMovement, _bitmap)
            {
                X = 101,
                Y = 499,
                Direction = AntDirection.RightUp,
                HorizontalVelocity = 1,
                VerticalVelocity = 1
            };

            // Act
            _blackAntMovement.Move(ant, _arenaSize);

            // Assert
            Assert.Equal(AntDirection.LeftDown, ant.Direction);
        }

        [Fact]
        public void Move_RightDownOutOfBoundsXAndY_ChangesDirectionToLeftUp()
        {
            // Arrange
            var ant = new AntBlack(_arenaSize, _random, _blackAntMovement, _bitmap)
            {
                X = 101,
                Y = 101,
                Direction = AntDirection.RightDown,
                HorizontalVelocity = 1,
                VerticalVelocity = 1
            };

            // Act
            _blackAntMovement.Move(ant, _arenaSize);

            // Assert
            Assert.Equal(AntDirection.LeftUp, ant.Direction);
        }

        [Fact]
        public void Move_LeftUpWithinBounds_UpdatesPositionCorrectly()
        {
            // Arrange
            var ant = new AntBlack(_arenaSize, _random, _blackAntMovement, _bitmap)
            {
                X = 50,
                Y = 50,
                Direction = AntDirection.LeftUp,
                HorizontalVelocity = 5,
                VerticalVelocity = 5
            };

            // Act
            _blackAntMovement.Move(ant, _arenaSize);

            // Assert
            Assert.Equal(45, ant.X);
            Assert.Equal(45, ant.Y);
            Assert.Equal(AntDirection.LeftDown, ant.Direction);
        }

        [Fact]
        public void Move_RightDownWithinBounds_UpdatesPositionCorrectly()
        {
            // Arrange
            var ant = new AntBlack(_arenaSize, _random, _blackAntMovement, _bitmap)
            {
                X = 50,
                Y = 50,
                Direction = AntDirection.RightDown,
                HorizontalVelocity = 5,
                VerticalVelocity = 5
            };

            // Act
            _blackAntMovement.Move(ant, _arenaSize);

            // Assert
            Assert.Equal(55, ant.X);
            Assert.Equal(55, ant.Y);
            Assert.Equal(AntDirection.RightDown, ant.Direction);
        }
    }
}