using System.Drawing;

namespace Bezier.Bezier.Output
{
	public interface IOutput
	{
		void Draw(PointF[] drawingPoints);
	}
}
