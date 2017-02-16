using ZedGraph;

namespace Bezier.DataLoaders
{
	public interface ILoader
	{
		PointPairList Load();
	}
}
