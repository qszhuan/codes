using TrainTestUsingVisitor.visitor;

namespace TrainTestUsingVisitor
{
    public class Edge
    {
        private Station StartStation { get; set; }
        private Station EndStation { get; set; }
        public int Distance { get; private set; }
        public bool Passed { get; set; }
        public const string NotExist = "NO SUCH ROUTE";

        public Edge(Station start, Station end, int distance)
        {
            StartStation = start;
            EndStation = end;
            Distance = distance;
            Passed = true;
        }

        public bool GoTo(string end)
        {
            return EndStation.Name == end;
        }

        public void PassThrough()
        {
            Passed = false;
        }

        public void Clear()
        {
            Passed = true;
        }

        public VisitStatus Accept(IRoadmapVisitor visitor)
        {
            var status = visitor.VisitEdge(this);
            return status != VisitStatus.GiveupOneRoute ? EndStation.Accept(visitor) : status;
        }

        public override string ToString()
        {
            return string.Format("[{0}]--({1})-->[{2}]", StartStation.Name, Distance, EndStation.Name);
        }
    }
}