using System.Linq;
using Xunit;

namespace TrainTest
{
    public class TrainTest
    {
        [Fact]
        public void should_got_path_between_adjacent_station()
        {
            var roadmap = new Roadmap();

            var trainPath = new TrainPath {Distance = 10, End = "B", Start = "A"};
            roadmap.AddPath(trainPath);

            Assert.Equal(1, roadmap.Paths("A", "B").Count());
            Assert.Equal(trainPath, roadmap.Paths("A", "B").First().First());
            Assert.Equal("10", roadmap.CalcPath("A", "B"));
        }

        [Fact]
        public void should_get_expected_output_if_no_path()
        {
            var roadmap = new Roadmap();

            var calcPath = roadmap.CalcPath("A", "B");
            Assert.Equal(TrainPath.NotExist, calcPath);

            var path = roadmap.CalcPath("A", "B", "C");
            Assert.Equal(TrainPath.NotExist, path);

            roadmap.AddPath(new TrainPath {Start = "A", End = "B", Distance = 10});

            path = roadmap.CalcPath("A", "B", "C");
            Assert.Equal(TrainPath.NotExist, path);
        }

        [Fact]
        public void should_get_path_when_have_more_than_two_station()
        {
            var roadmap = new Roadmap();
            roadmap.AddPath(new TrainPath {Start = "A", End = "B", Distance = 10});
            roadmap.AddPath(new TrainPath {Start = "B", End = "C", Distance = 5});

            var calcPath = roadmap.CalcPath("A","B","C");
            Assert.Equal("15", calcPath);
        }

        [Fact]
        public void should_get_trip_count_within_3_stops()
        {
            var roadmap = new Roadmap();
            Assert.Equal(0, roadmap.TripCount("A", "B", 3));
            roadmap.AddPath(new TrainPath{Start = "A", End = "B", Distance = 1});
            roadmap.AddPath(new TrainPath{Start = "B", End = "A", Distance = 1});
            roadmap.AddPath(new TrainPath{Start = "B", End = "C", Distance = 1});
            roadmap.AddPath(new TrainPath{Start = "A", End = "C", Distance = 1});

            Assert.Equal(3, roadmap.TripCount("A", "C", 3));
            Assert.Equal(0, roadmap.TripCount("D", "C", 3));
            Assert.Equal(2, roadmap.TripCount("A", "A", 4));
        }

        [Fact]
        public void should_get_trip_count_with_exactly_4_stops()
        {
            var roadmap = new Roadmap();
            Assert.Equal(0, roadmap.TripCountWithFixStops("A", "B", 4));

            roadmap.AddPath(new TrainPath {Start = "A", End = "B", Distance = 1});
            roadmap.AddPath(new TrainPath {Start = "B", End = "C", Distance = 1});
            roadmap.AddPath(new TrainPath {Start = "A", End = "C", Distance = 1});
            roadmap.AddPath(new TrainPath {Start = "B", End = "A", Distance = 1});

            Assert.Equal(1, roadmap.TripCountWithFixStops("A","C", 4));
        }

        [Fact]
        public void should_get_the_shortest_path_from_a_to_c()
        {
            var roadmap = new Roadmap();
            roadmap.AddPath(new TrainPath {Start = "A", End = "B", Distance = 1});
            roadmap.AddPath(new TrainPath {Start = "B", End = "C", Distance = 1});
            roadmap.AddPath(new TrainPath {Start = "A", End = "C", Distance = 3});

            Assert.Equal(2, roadmap.ShortestPath("A","C"));
        }
    }
}
