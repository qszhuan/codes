using System.Collections.Generic;
using System.Linq;

namespace TrainTestUsingVisitor.visitor
{
    public class FixRouteRoadmapVisitor:IRoadmapVisitor
    {
        public FixRouteRoadmapVisitor(params string[] stations)
        {
            Stations = stations;
            StartStation = stations.First();
            Result = Edge.NotExist;
        }

        public string StartStation { get; set; }
        private string[] Stations { get; set; }
        private readonly List<Edge> _visitedEdges = new List<Edge>();

        public string Result { private set; get;}

        public VisitStatus VisitEdge(Edge edge)
        {
            _visitedEdges.Add(edge);
            return VisitStatus.ContinueRoute;
        }

        public VisitStatus VisitStation(Station station)
        {
            var currentIndex = _visitedEdges.Count;
            if (currentIndex == Stations.Length) return VisitStatus.GiveupRoute;

            if (station.Name == Stations.ElementAt(currentIndex))
            {
                if (currentIndex + 1 == Stations.Length)
                {
                    Result = _visitedEdges.Sum(e => e.Distance).ToString();
                    return VisitStatus.GiveupRoute;
                }
            }
            return VisitStatus.ContinueRoute;
        }

        public void EnterStation(Station station)
        {
            
        }

        public void LeaveStation(Station station)
        {
//            if (_visitedEdges.Count == 0) return;
//            var lastEdgeIndex = _visitedEdges.Count-1;
//            _visitedEdges.RemoveAt(lastEdgeIndex);
        }
    }
}