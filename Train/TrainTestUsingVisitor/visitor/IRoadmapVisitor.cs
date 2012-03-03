namespace TrainTestUsingVisitor.visitor
{
    public interface IRoadmapVisitor
    {
        string StartStation { get; set; }
        VisitStatus VisitEdge(Edge edge);
        VisitStatus VisitStation(Station station);
        void EnterStation(Station station);
        void LeaveStation(Station station);
    }
}