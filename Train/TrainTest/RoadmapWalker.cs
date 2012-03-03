using System;
using System.Linq;

namespace TrainTest
{
    public class RoadmapWalker
    {
        private readonly Roadmap _roadmap;

        public RoadmapWalker(Roadmap roadmap)
        {
            _roadmap = roadmap;
        }

        public string CalculateDistance(string start, string next, params string[] followings)
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

        public int TripCountWithMaxStops(string start, string end, int maxStops)
        {
            var tripCount = 0;
            var trainPaths = _roadmap.PathsComeFrom(start);
            while (maxStops-- > 0)
            {
                if (trainPaths.Count() == 0) return tripCount;

                var paths = trainPaths.Where(path => path.GoTo(end));
                tripCount += paths.Count();
                trainPaths = _roadmap.TrainPaths.Where(path => trainPaths.Any(p=>p.Connected(path))).ToList();

            }
            return tripCount;
        }

        public int TripCountWithFixStops(string start, string end, int exactStops)
        {
            var trainPaths = _roadmap.PathsComeFrom(start);

            return exactStops == 0 ? trainPaths.Count(path=>path.GoTo(end))
                       : trainPaths.Sum(trainPath => TripCountWithFixStops(trainPath.End, end, exactStops - 1));
        }

        public int ShortestPath(string start, string end)
        {
            var shortestPath = Traverse(0, start, end, int.MaxValue);
            _roadmap.ClearStatus();
            return shortestPath;
        }

        public int Traverse(int alreadyTravelled, string start, string end, int currentShortestTrip)
        {
            var accessingPaths = _roadmap.TrainPaths.Where(path=>path.ComeFrom(start) && path.NeverRouted).ToList();
            foreach (var path in accessingPaths)
            {
                path.PassThrough();
                var travelled = alreadyTravelled + path.Distance;
                if (path.GoTo(end))
                {
                    currentShortestTrip = Math.Min(travelled, currentShortestTrip);
                    path.Clear();
                    continue;
                }

                var tripDistance = Traverse(travelled, path.End, end, currentShortestTrip);
                path.Clear();
                currentShortestTrip = Math.Min(tripDistance, currentShortestTrip);
            }
            return currentShortestTrip;
        }

        public int TripCountLessThanDistance(string start, string end, int maxDistance)
        {
            return GetCount(start, end, maxDistance, 0);
        }

        private int GetCount(string start, string end, int maxDistance, int alreadyTravelled)
        {
            var count = 0;
            var trainPaths = _roadmap.PathsComeFrom(start);

            foreach (var trainPath in trainPaths)
            {
                var travelled = alreadyTravelled + trainPath.Distance;
                if (travelled >= maxDistance) continue;
                if (trainPath.GoTo(end))
                {
                    count++;
                }
                count += GetCount(trainPath.End, end, maxDistance, travelled);
            }
            return count;
        }

        private int PathDistance(string start, string next)
        {
            var firstPath = _roadmap.TrainPaths.First(path => path.Match(start, next));
            return firstPath.Distance;
        }
    }
}