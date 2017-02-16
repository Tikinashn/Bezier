using System;
using System.Drawing;
using System.Windows.Forms;
using Bezier.Extentions;

namespace Bezier.Bezier
{
	/// <summary>
	/// Управляющий маркер
	/// </summary>
	public class Marker
	{
		/// <summary>
		/// Радиус маркера
		/// </summary>
		private const int Radius = 10;

		/// <summary>
		/// Флаг, определяющий начало перетаскивания
		/// </summary>
		private bool _drag;

		/// <summary>
		/// Ограничивающий прямоугольник
		/// </summary>
		private RectangleF _rectangle;

		/// <summary>
		/// Создание нового маркера
		/// </summary>
		/// <param name="x">Координата X</param>
		/// <param name="y">Координата Y</param>
		public Marker(float x, float y)
		{
			_rectangle = new RectangleF(x - Radius / 2f, y - Radius / 2f, Radius, Radius);
		}

		public Marker(PointF p)
		{
			_rectangle = new RectangleF(p.X, p.Y, Radius, Radius);
		}

		/// <summary>
		/// Событие, возникающее при перетаскивании
		/// </summary>
		public Action<PointF> OnDrag { get; set; }

		/// <summary>
		/// Собитие, возникающее при нажании на маркер
		/// </summary>
		public Action<PointF> OnMouseDown { get; set; }

		/// <summary>
		/// Положение маркера
		/// </summary>
		public PointF Location
		{
			get
			{
				return new PointF(_rectangle.X + Radius / 2f, _rectangle.Y + Radius / 2f);
			}
		}

		/// <summary>
		/// Отрисовка маркера
		/// </summary>
		/// <param name="g">График для отрисовки</param>
		public void Draw(Graphics g)
		{
			//var point = Bpoint.Apply(_rectangle.X - Radius / 2f, _rectangle.Y - Radius / 2f);
			//var rectangle = new RectangleF(point.X, point.Y, Radius, Radius);
			g.FillEllipse(Brushes.Black, _rectangle);
		}

		/// <summary>
		/// Необходимо вызывать при нажатии мыши
		/// </summary>
		public void MouseDown(MouseEventArgs e)
		{
			//var temp = Bpoint.DeApply(e.Location);
			if (_rectangle.Contains(e.Location))
			{
				_drag = true;
				OnMouseDown?.Invoke(e.Location);
			}
		}
		/// <summary>
		/// Необходмио вызывать при отпускании мыши
		/// </summary>
		public void MouseUp()
		{
			_drag = false;
		}

		/// <summary>
		/// Необходмо вызывать при передвижении мыши
		/// </summary>
		public void MouseMove(MouseEventArgs e)
		{
			if (!_drag)
			{
				return;
			}

			_rectangle.X = e.X - Radius / 2f;
			_rectangle.Y = e.Y - Radius / 2f;
			OnDrag?.Invoke(e.Location);
		}
	}
}
