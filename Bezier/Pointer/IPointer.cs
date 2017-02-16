using System.Drawing;

namespace Bezier.Bezier.Pointer
{
	public interface IPointer
	{
		PointF Get(PointF[] dataPoints, float t, int N);
	}
}
