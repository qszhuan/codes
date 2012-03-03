namespace TrainTestUsingVisitor.visitor
{
    public class StopLimitRoadmapVisitor : IRoadmapVisitor
    {
        public StopLimitRoadmapVisitor(string start, string end, int maxStops)
        {
            StartStation = start;
            EndStation = end;
            MaxStops = maxStops;
        }

        public string StartStation { get; set; }
        private string EndStation { get; set; }
        private int MaxStops { get; set; }
        public int RouteCount { get; set; }
        private int _alreadyStops;

        public VisitStatus VisitEdge(Edge edge)
        {
            return VisitStatus.ContinueRoute;
        }

        public VisitStatus VisitStation(Station station)
        {
            if (_alreadyStops > MaxStops)
            {
                return VisitStatus.GiveupOneRoute;
            }

            if (_alreadyStops != 0 && EndStation == station.Name)
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