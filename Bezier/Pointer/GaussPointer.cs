using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Interpolations.Interpolations.Factorys;
using Interpolations.Interpolations.ParametricInterpolation;
using ZedGraph;

namespace Bezier.Bezier.Pointer
{
	internal class GaussPointer : IPointer
	{
		private ParametricGaussInterpolation _parametricGaussInterpolation;

		public PointF Get(PointF[] dataPoints, float f, int N)
		{
			var t = 0.0;
			var convertedPoints = dataPoints.Select(item => new Tuple<double, PointD>(++t, new PointD(item.X, item.Y))).ToList();
			_parametricGaussInterpolation = InterpolationsMetodsFactory.CreateParametricGaussInterpolation(convertedPoints);

			var max = convertedPoints.Max(item => item.Item1);
			var maxT = ((max -1.0)* f)/ N + 1;// f / (N / max) ;

			var point = _parametricGaussInterpolation.F(maxT);

			return new PointF((float)point.X, (float)point.Y);
		}
	}
}
