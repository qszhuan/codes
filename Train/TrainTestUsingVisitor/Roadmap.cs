using System.Collections.Generic;
using System.Linq;
using TrainTestUsingVisitor.visitor;

namespace TrainTestUsingVisitor
{
    public class Roadmap
    {

        public HashSet<Station> Stations = new HashSet<Station>(); 
        public Roadmap()
        {
        }

        public void AddPath(string start, string end, int distance)
        {
            var startStation = AddStation(start);
            var endStation = AddStation(end);

            var edge = new Edge(startStation, endStation, distance);
            startStation.AddEdge(edge);
        }

        private Station AddStation(string stationName)
        {
            var find = Stations.FirstOrDefault(station=>station.Name == stationName);
            if (find == null)
            {
                find = new Station(stationName);
                Stations.Add(find);
            }
            return find;
        }

        public void Accept(IRoadmapVisitor visitor)
        {
            var startStation = Stations.SingleOrDefault(station=>station.Name == visitor.StartStation);
            if (startStation != null) startStation.Accept(visitor);
        }
    }
}