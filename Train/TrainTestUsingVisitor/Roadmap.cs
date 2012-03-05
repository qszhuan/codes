using System.Collections.Generic;
using System.Linq;
using TrainTestUsingVisitor.visitor;

namespace TrainTestUsingVisitor
{
    public class Roadmap
    {
        private readonly HashSet<Station> _stations = new HashSet<Station>();

        public void AddPath(string start, string end, int distance)
        {
            var startStation = AddStation(start);
            var endStation = AddStation(end);

            var edge = new Edge(startStation, endStation, distance);
            startStation.AddEdge(edge);
        }

        private Station AddStation(string stationName)
        {
            var find = _stations.FirstOrDefault(station=>station.Name == stationName);
            if (find == null)
            {
                find = new Station(stationName);
                _stations.Add(find);
            }
            return find;
        }

        public void Accept(IRoadmapVisitor visitor)
        {
            var startStation = _stations.SingleOrDefault(station=>station.Name == visitor.StartStation);
            if (startStation != null) startStation.Accept(visitor);
        }
    }
}