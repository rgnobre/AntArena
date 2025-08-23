using AntArena.Domain.Entities;
using AntArena.Domain.Enums;
using AntArena.Infrastructure.Factories;
using System.Drawing;

namespace AntArena.Tests.Infrastructure.Factory;

public class AntFactoryTests
{
    private readonly Size _arenaSize = new Size(100, 100);
    private readonly Random _random = new Random();
    private readonly Bitmap _image = new Bitmap(10, 10);
    private readonly AntFactory _antFactory;

    public AntFactoryTests()
    {
        _antFactory = new AntFactory(_arenaSize, _random, _image);
    }

    [Fact]
    public void Create_RedAnt_ReturnsRedAnt()
    {
        // Act
        var ant = _antFactory.Create(AntType.Red);

        // Assert
        Assert.IsType<AntRed>(ant);
    }

    [Fact]
    public void Create_YellowAnt_ReturnsYellowAnt()
    {
        // Act
        var ant = _antFactory.Create(AntType.Yellow);

        // Assert
        Assert.IsType<AntYellow>(ant);
    }

    [Fact]
    public void Create_BlackAnt_ReturnsBlackAnt()
    {
        // Act
        var ant = _antFactory.Create(AntType.Black);

        // Assert
        Assert.IsType<AntBlack>(ant);
    }

    [Fact]
    public void Create_WhiteAnt_ReturnsWhiteAnt()
    {
        // Act
        var ant = _antFactory.Create(AntType.White);

        // Assert
        Assert.IsType<AntWhite>(ant);
    }

    [Fact]
    public void Create_UnknownAntType_ThrowsInvalidOperationException()
    {
        // Arrange
        var unknownType = (AntType)999;

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => _antFactory.Create(unknownType));
        Assert.Equal($"Unknown AntType: {unknownType}", exception.Message);
    }
}