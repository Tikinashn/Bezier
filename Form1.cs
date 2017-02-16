using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Bezier.Bezier;
using Bezier.DataLoaders;
using Bezier.Extentions;
using ZedGraph;

namespace Bezier
{
	public partial class Form1 : Form
	{
		int N = 5;
		int count = 0;
		List<Marker[]> markerss = new List<Marker[]>();
		List<BezierCurve> beziers = new List<BezierCurve>();

		public Form1()
		{
			InitializeComponent();
			Bpoint.Center = new PointD(pB.Width/2.0, pB.Height/2.0);
			pB.MouseWheel += (sender, args) =>
			{
				var p = args.Delta/100;
				Bpoint.Zoom += p;
				pB.Refresh();
			};
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var op = new OpenFileDialog();
			var dr = op.ShowDialog();
			ILoader _loader;
			if (dr == DialogResult.OK)
			{
				count = 0;
				_loader = new FromFileLoader(op.FileName);
				var points = _loader.Load();

				var list = new List<PointF>();

				foreach (var point in points)
				{
					list.Add(Bpoint.Apply(point));
				}
				N = list.Count;
				New_Beze(list, count);
				count++;
				pB.Refresh();
			}
		}

		void New_Beze(List<PointF> list, int n)
		{
			Marker[] macr = new Marker[N];
			BezierCurve bezier = null;
			
			markerss.Add(list.Select(item => new Marker(item)).ToArray());

			for (int index = 0; index < N; index++)
			{
				Marker marker = markerss[n][index];
				int i = index;
				marker.OnDrag += f =>
				{
					bezier[i] = f;
					pB.Invalidate();
				};
				marker.OnMouseDown += f => { Cursor = Cursors.Hand; };
			}

			bezier = new BezierCurve(markerss[n].Select(m => m.Location).ToArray());
			beziers.Add(bezier);
		}

		private void pB_Click(object sender, EventArgs e)
		{

		}

		private void pB_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			var pen = new Pen(Color.Gray, 1f);

			foreach (Marker[] mark in markerss)
			{
				e.Graphics.DrawLines(pen, mark.Select(m => m.Location).ToArray());
				foreach (Marker marker in mark)
				{
					marker.Draw(e.Graphics);
				}
			}
			foreach (BezierCurve bezi in beziers)
			{
				bezi.Draw(e.Graphics);
			}
		}

		private void pB_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{

				foreach (Marker[] mark in markerss)
				{
					foreach (Marker marker in mark)
					{
						marker.MouseMove(e);
						Thread.Sleep(0);
					}
				}

			}
		}

		private void pB_MouseDown(object sender, MouseEventArgs e)
		{
			foreach (Marker[] mark in markerss)
			{
				foreach (Marker marker in mark)
				{
					marker.MouseDown(e);
				}
			}
		}

		private void pB_MouseUp(object sender, MouseEventArgs e)
		{
			foreach (Marker[] mark in markerss)
			{
				foreach (Marker marker in mark)
				{
					marker.MouseUp();
				}
			}
			Cursor = Cursors.Arrow;
		}
	}
}
