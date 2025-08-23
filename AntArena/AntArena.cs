using AntArena.Domain.Interfaces;
using System;
using System.Windows.Forms;

namespace Ant_3_Arena
{
    public partial class AntArena : Form
    {
        private readonly IArenaSimulation _arenaSimulation;
        private readonly IRenderer _renderer;

        public AntArena(IArenaSimulation arenaSimulation, IRenderer renderer)
        {
            _arenaSimulation = arenaSimulation;
            _renderer = renderer;

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.bg;
            _arenaSimulation.InitializeAnts(3);
        }

        private void AntArena_Paint(object sender, PaintEventArgs e)
        {
            _renderer.SetGraphics(e.Graphics);
            _arenaSimulation.Render(_renderer);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _arenaSimulation.Update(ClientSize);
            Invalidate();
        }

        private void AntArena_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }
    }
}
