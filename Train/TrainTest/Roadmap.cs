using System.Collections.Generic;
using System.Linq;

namespace TrainTest
{
    public class Roadmap
    {
        public List<TrainPath> TrainPaths { get; private set; }

        public Roadmap()
        {
            TrainPaths = new List<TrainPath>();
        }

        public void AddPath(string start, string end, int distance)
        {
            var trainPath = new TrainPath(start, end, distance);
            if (!TrainPaths.Any(path => path.Match(trainPath)))
                TrainPaths.Add(trainPath);
        }

        public void ClearStatus()
        {
            TrainPaths.ForEach(path => path.Clear());
        }

        public IEnumerable<TrainPath> PathsComeFrom(string start)
        {
            return TrainPaths.Where(path=>path.ComeFrom(start)).ToList();
        }
    }
}