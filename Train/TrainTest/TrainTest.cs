using System.Linq;
using Xunit;

namespace TrainTest
{
    public class TrainTest
    {
        [Fact]
        public void should_get_expected_output_if_no_path()
        {
            var roadmap = new Roadmap();
            var calcPath = roadmap.CalculateDistance("A", "B");
            Assert.Equal(TrainPath.NotExist, calcPath);

            roadmap.AddPath(new TrainPath("A","B",10));
            var path = roadmap.CalculateDistance("A", "B", "C");
            Assert.Equal(TrainPath.NotExist, path);
        }

        [Fact]
        public void should_get_path_when_have_more_than_two_station()
        {
            var roadmap = new Roadmap();
            roadmap.AddPath(new TrainPath("A", "B", 10));
            roadmap.AddPath(new TrainPath("B", "C", 5));

            var calcPath = roadmap.CalculateDistance("A","B","C");
            Assert.Equal("15", calcPath);
        }

        [Fact]
        public void should_get_trip_count_within_3_stops()
        {
            var roadmap = new Roadmap();
            Assert.Equal(0, roadmap.TripCountWithMaxStops("A", "B", 3));
            roadmap.AddPath(new TrainPath("A","B",1));
            roadmap.AddPath(new TrainPath("B","A",1));
            roadmap.AddPath(new TrainPath("B","C",1));
            roadmap.AddPath(new TrainPath("A","C",1));

            Assert.Equal(3, roadmap.TripCountWithMaxStops("A", "C", 3));
            Assert.Equal(0, roadmap.TripCountWithMaxStops("D", "C", 3));
            Assert.Equal(2, roadmap.TripCountWithMaxStops("A", "A", 4));
        }

        [Fact]
        public void should_get_trip_count_with_exactly_4_stops()
        {
            var roadmap = new Roadmap();
            Assert.Equal(0, roadmap.TripCountWithFixStops("A", "B", 4));

            roadmap.AddPath(new TrainPath("A","B",1));
            roadmap.AddPath(new TrainPath("B","C",1));
            roadmap.AddPath(new TrainPath("A","C",1));
            roadmap.AddPath(new TrainPath("B","A",1));

            Assert.Equal(1, roadmap.TripCountWithFixStops("A","C", 4));
        }

        [Fact]
        public void should_get_the_shortest_path_from_a_to_c()
        {
            var roadmap = new Roadmap();
            roadmap.AddPath(new TrainPath("A", "B", 5));
            roadmap.AddPath(new TrainPath("B", "C", 5));
            Assert.Equal(10, roadmap.ShortestPath("A","C"));

            roadmap.AddPath(new TrainPath("A", "C", 9));
            Assert.Equal(9, roadmap.ShortestPath("A","C"));

            roadmap.AddPath(new TrainPath("A","D",1));
            roadmap.AddPath(new TrainPath("D","B",1));
            Assert.Equal(7, roadmap.ShortestPath("A","C"));
        }

        [Fact]
        public void should_get_the_shortest_path_from_a_to_a()
        {
            var roadmap = new Roadmap();
            roadmap.AddPath(new TrainPath("A", "B", 5));
            roadmap.AddPath(new TrainPath("B", "A", 5));
            Assert.Equal(10, roadmap.ShortestPath("A", "A"));


            roadmap.AddPath(new TrainPath("A", "D", 1));
            roadmap.AddPath(new TrainPath("D", "A", 1));
            Assert.Equal(2, roadmap.ShortestPath("A", "A"));  
        }

        [Fact]
        public void should_get_trip_count_within_certain_distance()
        {
            var roadmap = new Roadmap();
            Assert.Equal(0, roadmap.TripCountLessThanDistance("A", "B", 5));
            roadmap.AddPath(new TrainPath("A", "B", 1));
            roadmap.AddPath(new TrainPath("B", "A", 1));
            roadmap.AddPath(new TrainPath("B", "C", 1));
            roadmap.AddPath(new TrainPath("A", "C", 1));

            Assert.Equal(4, roadmap.TripCountLessThanDistance("A", "C", 5));
            Assert.Equal(2, roadmap.TripCountLessThanDistance("A", "A", 5));
        }
    }
}
