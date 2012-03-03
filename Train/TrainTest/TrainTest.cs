using Xunit;

namespace TrainTest
{
    public class TrainTest
    {
        [Fact]
        public void should_get_expected_output_if_no_path()
        {
            var roadmap = new Roadmap();
            var roadmapWalker = new RoadmapWalker(roadmap);

            var calcPath = roadmapWalker.CalculateDistance("A", "B");
            Assert.Equal(TrainPath.NotExist, calcPath);

            roadmap.AddPath("A", "B", 10);
            var path = roadmapWalker.CalculateDistance("A", "B", "C");
            Assert.Equal(TrainPath.NotExist, path);
        }

        [Fact]
        public void should_get_path_when_have_more_than_two_station()
        {
            var roadmap = new Roadmap();
            roadmap.AddPath("A", "B", 10);
            roadmap.AddPath("B", "C", 5);

            var roadmapWalker = new RoadmapWalker(roadmap);
            var calcPath = roadmapWalker.CalculateDistance("A","B","C");
            Assert.Equal("15", calcPath);
        }

        [Fact]
        public void should_get_trip_count_within_3_stops()
        {
            var roadmap = new Roadmap();
            var roadmapWalker = new RoadmapWalker(roadmap);

            Assert.Equal(0, roadmapWalker.TripCountWithMaxStops("A", "B", 3));

            roadmap.AddPath("A", "B", 1);
            roadmap.AddPath("B", "A", 1);
            roadmap.AddPath("B", "C", 1);
            roadmap.AddPath("A", "C", 1);

            Assert.Equal(3, roadmapWalker.TripCountWithMaxStops("A", "C", 3));
            Assert.Equal(0, roadmapWalker.TripCountWithMaxStops("D", "C", 3));
            Assert.Equal(2, roadmapWalker.TripCountWithMaxStops("A", "A", 4));
        }

        [Fact]
        public void should_get_trip_count_with_exactly_4_stops()
        {
            var roadmap = new Roadmap();
            var roadmapWalker = new RoadmapWalker(roadmap);

            Assert.Equal(0, roadmapWalker.TripCountWithFixStops("A", "B", 4));

            roadmap.AddPath("A", "B", 1);
            roadmap.AddPath("B", "C", 1);
            roadmap.AddPath("A", "C", 1);
            roadmap.AddPath("B", "A", 1);

            Assert.Equal(1, roadmapWalker.TripCountWithFixStops("A","C", 4));
        }

        [Fact]
        public void should_get_the_shortest_path_from_a_to_c()
        {
            var roadmap = new Roadmap();
            var roadmapWalker = new RoadmapWalker(roadmap);

            roadmap.AddPath("A", "B", 5);
            roadmap.AddPath("B", "C", 5);
            Assert.Equal(10, roadmapWalker.ShortestPath("A","C"));

            roadmap.AddPath("A", "C", 9);
            Assert.Equal(9, roadmapWalker.ShortestPath("A","C"));

            roadmap.AddPath("A", "D", 1);
            roadmap.AddPath("D", "B", 1);
            Assert.Equal(7, roadmapWalker.ShortestPath("A","C"));
        }

        [Fact]
        public void should_get_the_shortest_path_from_a_to_a()
        {
            var roadmap = new Roadmap();
            var roadmapWalker = new RoadmapWalker(roadmap);

            roadmap.AddPath("A", "B", 5);
            roadmap.AddPath("B", "A", 5);
            Assert.Equal(10, roadmapWalker.ShortestPath("A", "A"));


            roadmap.AddPath("A", "D", 1);
            roadmap.AddPath("D", "A", 1);
            Assert.Equal(2, roadmapWalker.ShortestPath("A", "A"));  
        }

        [Fact]
        public void should_get_trip_count_within_certain_distance()
        {
            var roadmap = new Roadmap();
            var roadmapWalker = new RoadmapWalker(roadmap);

            Assert.Equal(0, roadmapWalker.TripCountLessThanDistance("A", "B", 5));
            roadmap.AddPath("A", "B", 1);
            roadmap.AddPath("B", "A", 1);
            roadmap.AddPath("B", "C", 1);
            roadmap.AddPath("A", "C", 1);

            Assert.Equal(4, roadmapWalker.TripCountLessThanDistance("A", "C", 5));
            Assert.Equal(2, roadmapWalker.TripCountLessThanDistance("A", "A", 5));
        }
    }
}
