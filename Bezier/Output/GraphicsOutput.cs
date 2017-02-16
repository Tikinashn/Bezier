using System.Drawing;

namespace Bezier.Bezier.Output
{
	class GraphicsOutput : IOutput
	{
		private readonly Graphics _graphics;

		public GraphicsOutput(Graphics g)
		{
			_graphics = g;
		}

		public void Draw(PointF[] drawingPoints)
		{
			
		}
	}
}
