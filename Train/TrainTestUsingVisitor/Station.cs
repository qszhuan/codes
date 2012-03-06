using System.Collections.Generic;
using TrainTestUsingVisitor.visitor;

namespace TrainTestUsingVisitor
{
    public class Station
    {
        public string Name { get; private set; }
        public List<Edge> Edges = new List<Edge>();

        public Station(string name)
        {
            Name = name;
        }
        public void AddEdge(Edge path)
        {
            Edges.Add(path);
        }

        public void Accept(IRoadmapVisitor visitor)
        {
            visitor.EnterStation(this);
            if (visitor.VisitStation(this) != VisitStatus.ContinueRoute)
            {
                visitor.LeaveStation(this);
                return;
            }

            foreach (var edge in Edges)
            {
                if (visitor.VisitEdge(edge) == VisitStatus.GiveupRoute) continue;
                edge.EndStation.Accept(visitor);
            }
            visitor.LeaveStation(this);
        }
    }

    public enum VisitStatus
    {
        ContinueRoute,
        GiveupRoute
    }
}