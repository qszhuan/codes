namespace TrainTestUsingVisitor.visitor
{
    public class ExactStopsRoadmapVisitor : IRoadmapVisitor
    {
        public ExactStopsRoadmapVisitor(string start, string end, int exactStops)
        {
            _exactStops = exactStops;
            StartStation = start;
            EndStation = end;
        }

        public string StartStation { get; set; }
        private string EndStation { get; set; }

        public int RouteCount { get; set; }

        private readonly int _exactStops;
        private int _alreadyStops;

        public VisitStatus VisitEdge(Edge edge)
        {
            return VisitStatus.ContinueRoute;
        }

        public VisitStatus VisitStation(Station station)
        {
            if (_alreadyStops > _exactStops)
            {
                return VisitStatus.GiveupRoute;
            }

            if (EndStation == station.Name && _alreadyStops == _exactStops)
            {
                RouteCount++;
            }
            return VisitStatus.ContinueRoute;
        }

        public void EnterStation(Station station)
        {
            if (_alreadyStops != 0 || station.Name != StartStation)
                _alreadyStops++;
        }

        public void LeaveStation(Station station)
        {
            if (_alreadyStops != 0 || station.Name != StartStation)
                _alreadyStops--;
        }
    }
}