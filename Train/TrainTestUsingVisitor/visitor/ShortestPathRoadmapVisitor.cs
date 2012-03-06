using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainTestUsingVisitor.visitor
{
    public class ShortestPathRoadmapVisitor : IRoadmapVisitor
    {
        private readonly List<Edge> _visitedEdges = new List<Edge>();

        public ShortestPathRoadmapVisitor(string start, string end)
        {
            StartStation = start;
            EndStation = end;
            ShortestDistance = int.MaxValue;
        }

        public string StartStation { get; set; }
        private string EndStation { get; set; }

        public int ShortestDistance { get; set; }

        public VisitStatus VisitEdge(Edge edge)
        {
            if (!edge.Passed)
                return VisitStatus.GiveupRoute;

            edge.PassThrough();
            _visitedEdges.Add(edge);
            return VisitStatus.ContinueRoute;
        }

        public VisitStatus VisitStation(Station station)
        {
            if(_visitedEdges.Count == 0) return VisitStatus.ContinueRoute;

            var routedDistance = _visitedEdges.Sum(e => e.Distance);
            var tooFar = routedDistance > ShortestDistance;
            if (tooFar) return VisitStatus.GiveupRoute;

            if (station.Name == EndStation)
            {
                ShortestDistance = routedDistance;
                Print();
                return VisitStatus.GiveupRoute;
            }

            return VisitStatus.ContinueRoute;
        }

        public void LeaveStation(Station station)
        {
            if (_visitedEdges.Count == 0 ) return;

            var lastEdge = _visitedEdges.Last();
            lastEdge.Clear();
            _visitedEdges.Remove(lastEdge);
        }

        private void Print()
        {
            Console.Write("Current Shortest Route: " + string.Join(", ", _visitedEdges.Select(e => e.ToString())));
            Console.WriteLine();
        }

        public void EnterStation(Station station)
        {
            
        }
    }
}