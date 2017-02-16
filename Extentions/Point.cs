using System.Drawing;
using ZedGraph;

namespace Bezier.Extentions
{
	static class Bpoint
	{
		public static double Zoom = 30.0;
		public static PointD Center;

		public static PointF Apply(PointF point)
		{
			var newPoint = new PointF((float) (point.X*Zoom + Center.X), (float) (point.Y*Zoom + Center.Y));
			return newPoint;
		}

		public static PointF DeApply(PointF point)
		{
			return new PointF((float) ((point.X - Center.X)/Zoom), (float) ((point.Y - Center.Y)/Zoom));
		}

		public static PointF Apply(float x, float y)
		{
			return new PointF((float)(x * Zoom + Center.X), (float)(y * Zoom + Center.Y));
		}
	}
}
