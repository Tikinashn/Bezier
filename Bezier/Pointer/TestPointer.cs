using System.Drawing;

namespace Bezier.Bezier.Pointer
{
	class TestPointer : IPointer
	{
		/// <summary>
		/// Функция кривой
		/// </summary>
		/// <param name="dataPoints">Опорные точки</param>
		/// <param name="t">Параметр. Может изменяться от 0 до 1</param>
		/// <returns>Точка кирвой</returns>
		public PointF Get(PointF[] dataPoints, float t, int N)
		{
			//квадратическая безье
			var c0 = (1 - t) * (1 - t);
			var c1 = 2 * t * (1 - t);
			var c2 = t * t;
			var x = c0 * dataPoints[0].X + c1 * dataPoints[1].X + c2 * dataPoints[2].X;// + c3 * _dataPoints[3].X;
			var y = c0 * dataPoints[0].Y + c1 * dataPoints[1].Y + c2 * dataPoints[2].Y;// +c3 * _dataPoints[3].Y;
			return new PointF(x, y);
		}
	}
}
