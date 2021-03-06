﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bezier.Bezier.Pointer;
using Interpolations.Interpolations.Factorys;
using Interpolations.Interpolations.ParametricInterpolation;
using ZedGraph;

namespace Bezier.Bezier
{
	/// <summary>
	/// Кривоая безье
	/// </summary>
	public class BezierCurve
	{
		/// <summary>
		/// Количество точек для кривой.
		/// </summary>
		private const int DravingPointsNumber = 200;

		/// <summary>
		/// Шаг для отривсовки
		/// </summary>
		private const float Dt = 1f / DravingPointsNumber;

		///// <summary>
		///// Количество опорных точек кривой
		///// </summary>
		//private const int N = 15;

		/// <summary>
		/// Опорные точки.
		/// </summary>
		private PointF[] _dataPoints;

		/// <summary>
		/// Функция получения новой точки кривой
		/// </summary>
		private IPointer Pointer { get;}

		public Marker[] _markers { get; set; }

		/// <summary>
		/// Создание кривой безье
		/// </summary>
		/// <param name="points">Опроные точки</param>
		public BezierCurve(PointF[] points, Action action, Cursor cursor)
		{
			_markers = new Marker[points.Length];

			var markerssList = points.Select(item => new Marker(item)).ToArray();

			for (var index = 0; index < points.Length; index++)
			{
				var marker = _markers[index] =  markerssList[index];
				var i = index;
				marker.OnDrag += f =>
				{
					this[i] = f;
					action.Invoke();
				};
				marker.OnMouseDown += f => { cursor = Cursors.Hand; };
			}

			_dataPoints = markerssList.Select(m => m.Location).ToArray();
			Pointer = new GaussPointer();
			Invalidate();
		}

		/// <summary>
		/// Точки для отрисовки
		/// </summary>
		public PointF[] DrawingPoints { get; private set; }

		/// <summary>
		/// Опорные точки
		/// </summary>
		public PointF[] DataPoints
		{
			get
			{
				return _dataPoints;
			}
			set
			{
				_dataPoints = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Опорная точка
		/// </summary>
		/// <param name="i">Индекс опорной точки</param>
		public PointF this[int i]
		{
			get
			{
				return _dataPoints[i];
			}
			set
			{
				_dataPoints[i] = value;
				Invalidate();
			}
		}

		ParametricGaussInterpolation _parametricGaussInterpolation;

		/// <summary>
		/// Обновить точки для отрисовки.
		/// </summary>
		public void Invalidate()
		{
			DrawingPoints = new PointF[DravingPointsNumber + 1];

			var t = 0.0;
			var convertedPoints = _dataPoints.Select(item => new Tuple<double, PointD>(++t, new PointD(item.X, item.Y))).ToList();
			_parametricGaussInterpolation = InterpolationsMetodsFactory.CreateParametricGaussInterpolation(convertedPoints);

			var max = convertedPoints.Max(item => item.Item1);


			for (var i = 0; i <= DravingPointsNumber; i++)
			{
				var maxT = ((max - 1.0) * i) / DravingPointsNumber + 1;
				var point = _parametricGaussInterpolation.F(maxT);

				DrawingPoints[i] = new PointF((float)point.X, (float)point.Y);
			}

		}

		// TODO: обобщить средство вывода
		/// <summary>
		/// Отрисовка кривой.
		/// </summary>
		public void Draw(Graphics g)
		{
			var pen = new Pen(Color.Black, 2f);
			var helpLinesPen = new Pen(Color.Gray, 1f);
			g.DrawLines(helpLinesPen, _markers.Select(m => m.Location).ToArray());
			g.DrawLines(pen, DrawingPoints);
		}
	}
}
