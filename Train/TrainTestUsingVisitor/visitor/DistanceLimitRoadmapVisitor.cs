using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainTestUsingVisitor.visitor
{
    public class DistanceLimitRoadmapVisitor:IRoadmapVisitor
    {
        public DistanceLimitRoadmapVisitor(string start, string end, int maxDistance)
        {
            _maxDistance = maxDistance;
            StartStation = start;
            EndStation = end;
        }

        private readonly List<Edge> _routedEdges = new List<Edge>();

        public int RouteCount { get; set; }

        public string StartStation { get; set; }
        private string EndStation { get; set; }
        private readonly int _maxDistance;

        public VisitStatus VisitEdge(Edge edge)
        {
            if (_routedEdges.Sum(e => e.Distance)+ edge.Distance >= _maxDistance) return VisitStatus.GiveupRoute;
            _routedEdges.Add(edge);
//            Print();
            return VisitStatus.ContinueRoute;
        }

        public VisitStatus VisitStation(Station station)
        {
            if (_routedEdges.Count != 0 && _routedEdges.Sum(e=>e.Distance) < _maxDistance && station.Name == EndStation)
            {
                RouteCount++;
                Print();
            }
            return VisitStatus.ContinueRoute;
        }

        private void Print()
        {
            Console.Write("Route: " + string.Join(", ", _routedEdges.Select(e=>e.ToString())));
            Console.WriteLine();
        }

        public void EnterStation(Station station)
        {
        }

        public void LeaveStation(Station station)
        {
            if (_routedEdges.Count != 0 || station.Name != StartStation)
            {
                _routedEdges.RemoveAt(_routedEdges.Count-1);
            }
        }
    }
}