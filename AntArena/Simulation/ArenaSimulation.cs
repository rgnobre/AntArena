using AntArena.Domain.Enums;
using AntArena.Domain.Interfaces;
using System.Collections.Generic;
using System.Drawing;

namespace Ant_3_Arena.Simulation;

public class ArenaSimulation : IArenaSimulation
{
    private readonly List<IAnt> _ants = new List<IAnt>();

    private readonly IAntFactory _antFactory;

    public ArenaSimulation(IAntFactory factory)
    {
        _antFactory = factory;
    }

    public void InitializeAnts(int antQuantity)
    {
        _ants.Clear();

        for (int i = 0; i < antQuantity; i++)
        {
            _ants.Add(_antFactory.Create(AntType.Red));
            _ants.Add(_antFactory.Create(AntType.Yellow));
            _ants.Add(_antFactory.Create(AntType.Black));
            _ants.Add(_antFactory.Create(AntType.White));
        }
    }

    public void Update(Size bounds)
    {
        foreach (var ant in _ants) ant.Move(bounds);
    }

    public void Render(IRenderer renderer)
    {
        foreach (var ant in _ants) ant.Draw(renderer);
    }
}