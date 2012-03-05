using System.Collections.Generic;
using TrainTestUsingVisitor.visitor;

namespace TrainTestUsingVisitor
{
    public class Station
    {
        public string Name { get; private set; }
        public List<Edge> OutboundEdges = new List<Edge>();

        public Station(string name)
        {
            Name = name;
        }
        public void AddEdge(Edge path)
        {
            OutboundEdges.Add(path);
        }

        public VisitStatus Accept(IRoadmapVisitor visitor)
        {
            visitor.EnterStation(this);
            var visitStatus = visitor.VisitStation(this);
            if (visitStatus != VisitStatus.ContinueRoute)
            {
                visitor.LeaveStation(this);
                return visitStatus;
            }

            foreach (var edge in OutboundEdges)
            {
                var status = edge.Accept(visitor);
                if (status != VisitStatus.Satisfied) continue;

                visitor.LeaveStation(this);
                return status;
            }
            visitor.LeaveStation(this);
            return visitStatus;
        }
    }

    public enum VisitStatus
    {
        ContinueRoute,
        GiveupOneRoute,
        Satisfied
    }
}