using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainTest
{
    public class Roadmap
    {
        private readonly List<TrainPath> _trainPaths = new List<TrainPath>();

        public IEnumerable<List<TrainPath>> Paths(string start, string end)
        {
            var list = new List<List<TrainPath>>();
            var trainPath = _trainPaths.Where(path=>path.Start == start && path.End == end);
            list.Add(trainPath.ToList());
            return list;
        }

        public void AddPath(TrainPath trainPath)
        {
            if (!_trainPaths.Any(path=>path.Start == trainPath.Start && path.End == trainPath.End))
                _trainPaths.Add(trainPath);
        }

        public string CalcPath(string start, string next, params string[] followings)
        {
            int distance;
            try
            {
                distance = PathDistance(start, next);
                foreach (var station in followings)
                {
                    distance += PathDistance(next, station);
                    next = station;
                }
            }
            catch (Exception)
            {
                return TrainPath.NotExist;
            }
            return distance.ToString();
            
        }

        private int PathDistance(string start, string next)
        {
            var distance = 0;
            var firstPath = _trainPaths.First(path => path.Start == start && path.End == next);
            distance += firstPath.Distance;
            return distance;
        }

        public int TripCount(string start, string end, int maxStops)
        {
            var tripCount = 0;
            var trainPaths = _trainPaths.Where(path=>path.Start == start);
            while (maxStops-- > 0)
            {
                if (trainPaths.Count() == 0) return tripCount;

                var ends = trainPaths.Select(path=>path.End).ToList();
                tripCount += ends.Count(station => station == end);

                trainPaths = _trainPaths.Where(path => ends.Contains(path.Start));

            }
            return tripCount;
        }

        public int TripCountWithFixStops(string start, string end, int exactStops)
        {
            var trainPaths = _trainPaths.Where(path=>path.Start == start);

            return exactStops == 0 ? trainPaths.Select(path=>path.End).Count(station=>station == end) 
                : trainPaths.Sum(trainPath => TripCountWithFixStops(trainPath.End, end, exactStops - 1));
        }

        public int ShortestPath(string start, string end)
        {
            var shortestPath = int.MaxValue;

            var trainPaths = _trainPaths.Where(path=>path.Start == start);
           
            foreach (var trainPath in trainPaths)
            {
                if (trainPath.End == end && trainPath.Distance < shortestPath)
                    shortestPath = trainPath.Distance;
            }
            return 0;

        }
    }
}