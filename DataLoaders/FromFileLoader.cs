using System.IO;
using System.Linq;
using ZedGraph;

namespace Bezier.DataLoaders
{
	internal class FromFileLoader : ILoader
	{
		private string _fileName;

		public FromFileLoader(string fileName)
		{
			_fileName = fileName;
		}

		public PointPairList Load()
		{
			var points = new PointPairList();

			File.ReadAllLines(_fileName).ToList().ForEach(s =>
			{
				var arr = s.Split('\t');//разделитель до которого считываем
				points.Add(double.Parse(arr[0]), double.Parse(arr[1]));
			});
			return points;
		}
	}
}
