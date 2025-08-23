using AntArena.Domain.Entities;
using AntArena.Domain.Enums;
using AntArena.Domain.Interfaces;
using AntArena.Infrastructure.Movements;
using System.Drawing;

namespace AntArena.Infrastructure.Factories
{
    public class AntFactory : IAntFactory
    {
        private readonly Dictionary<AntType, Func<Size, Random, IAnt>> _registry = new Dictionary<AntType, Func<Size, Random, IAnt>>();
        private readonly Size _arenaSize;
        private readonly Random _random;
        private readonly Bitmap _image;
        public AntFactory(Size arenaSize, Random random, Bitmap image)
        {
            _arenaSize = arenaSize;
            _random = random;
            _image = image;
        }

        public IAnt Create(AntType type)
        {
            return type switch
            {
                AntType.Red => new AntRed(_arenaSize, _random, new DefaultMovement(), _image),
                AntType.Yellow => new AntYellow(_arenaSize, _random, new DefaultMovement(), _image),
                AntType.Black => new AntBlack(_arenaSize, _random, new BlackAntMovement(), _image),
                AntType.White => new AntWhite(_arenaSize, _random, new WhiteAntMovement(), _image),
                _ => throw new InvalidOperationException($"Unknown AntType: {type}")
            };
        }
    }
}
