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
				_loader = new FromFileLoader(op.FileName);
				var points = _loader.Load();

				var list = new List<PointF>();

				foreach (var point in points)
				{
					list.Add(Bpoint.Apply(point));
				}
				beziers.Add(new BezierCurve(list.ToArray(), pB.Invalidate, Cursor));
				pB.Refresh();
			}
		}

		private void pB_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			var pen = new Pen(Color.Gray, 1f);

			foreach (var bezi in beziers)
			{
				bezi.Draw(e.Graphics);
				//e.Graphics.DrawLines(pen, bezi._markers.Select(m => m.Location).ToArray());

				foreach (var marker in bezi._markers)
				{
					marker.Draw(e.Graphics);
				}
			}
		}

		private void pB_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				foreach (var bezi in beziers)
				{
					foreach (var marker in bezi._markers)
					{
						marker.MouseMove(e);
						Thread.Sleep(0);
					}
				}
			}
		}

		private void pB_MouseDown(object sender, MouseEventArgs e)
		{
			foreach (var bezi in beziers)
			{
				foreach (var marker in bezi._markers)
				{
					marker.MouseDown(e);
				}
			}
		}

		private void pB_MouseUp(object sender, MouseEventArgs e)
		{
			foreach (var bezi in beziers)
			{
				foreach (var marker in bezi._markers)
				{
					marker.MouseUp();
				}
			}
			Cursor = Cursors.Arrow;
		}
	}
}
