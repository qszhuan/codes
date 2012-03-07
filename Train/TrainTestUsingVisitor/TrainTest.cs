using TrainTestUsingVisitor.visitor;
using Xunit;

namespace TrainTestUsingVisitor
{
    public class TrainTest
    {
        [Fact]
        public void should_get_expected_output_if_no_path()
        {
            var roadmap = new Roadmap();

            var visitor = new FixRouteRoadmapVisitor("A", "B");
            roadmap.Accept(visitor);
            Assert.Equal(Edge.NotExist, visitor.Result);

            roadmap.AddPath("A", "B", 10);
            roadmap.AddPath("B", "D", 10);
            visitor = new FixRouteRoadmapVisitor("A", "B","C");
            roadmap.Accept(visitor);
            Assert.Equal(Edge.NotExist, visitor.Result);
        }

        [Fact]
        public void should_get_path_when_have_more_than_two_station()
        {
            var roadmap = new Roadmap();
            roadmap.AddPath("A", "B", 10);
            roadmap.AddPath("B", "C", 5);

            var visitor = new FixRouteRoadmapVisitor("A","B","C");
            roadmap.Accept(visitor);
            Assert.Equal("15", visitor.Result);
        }

        [Fact]
        public void should_get_trip_count_within_3_stops()
        {
            var roadmap = new Roadmap();
            var visitor = new StopLimitRoadmapVisitor("A", "B", 3);
            roadmap.Accept(visitor);
            Assert.Equal(0, visitor.RouteCount);

            roadmap.AddPath("A", "B", 1);
            roadmap.AddPath("B", "A", 1);
            roadmap.AddPath("B", "C", 1);
            roadmap.AddPath("A", "C", 1);

            visitor = new StopLimitRoadmapVisitor("A","C",3);
            roadmap.Accept(visitor);
            Assert.Equal(3, visitor.RouteCount);

            visitor = new StopLimitRoadmapVisitor("D", "C", 3);
            roadmap.Accept(visitor);
            Assert.Equal(0, visitor.RouteCount);

            visitor = new StopLimitRoadmapVisitor("A", "A", 4);
            roadmap.Accept(visitor);
            Assert.Equal(2, visitor.RouteCount);
        }

        [Fact]
        public void should_get_trip_count_with_exactly_4_stops()
        {
            var roadmap = new Roadmap();
            var visitor = new ExactStopsRoadmapVisitor("A", "B", 4);
            roadmap.Accept(visitor);

            Assert.Equal(0, visitor.RouteCount);

            roadmap.AddPath("A", "B", 1);
            roadmap.AddPath("B", "C", 1);
            roadmap.AddPath("A", "C", 1);
            roadmap.AddPath("B", "A", 1);

            visitor = new ExactStopsRoadmapVisitor("A", "C", 4);
            roadmap.Accept(visitor);
            Assert.Equal(1, visitor.RouteCount);
        }

        [Fact]
        public void should_return_int_max_when_path_not_found()
        {
            var roadmap = new Roadmap();
            roadmap.AddPath("A", "B", 5);
            roadmap.AddPath("B", "C", 5);
            roadmap.AddPath("B", "A", 5);
            var visitor = new ShortestPathRoadmapVisitor("A","D");
            roadmap.Accept(visitor);
            Assert.Equal(int.MaxValue, visitor.ShortestDistance);
        }

        [Fact]
        public void should_get_the_shortest_path_from_a_to_c()
        {
            var roadmap = new Roadmap();
            
            var visitor = new ShortestPathRoadmapVisitor("A", "C");
            roadmap.Accept(visitor);
            Assert.Equal(int.MaxValue, visitor.ShortestDistance);

            roadmap.AddPath("A", "C", 9);
            roadmap.Accept(visitor);
            Assert.Equal(9, visitor.ShortestDistance);

            roadmap.AddPath("A", "D", 1);
            roadmap.AddPath("D", "B", 1);
            roadmap.AddPath("B", "C", 5);
            roadmap.Accept(visitor);

            roadmap.AddPath("A", "E", 2);
            roadmap.AddPath("E", "C", 3);
            roadmap.Accept(visitor);

            Assert.Equal(5, visitor.ShortestDistance);
        }

        [Fact]
        public void should_get_the_shortest_path_from_a_to_a()
        {
            var roadmap = new Roadmap();
            var visitor = new ShortestPathRoadmapVisitor("A", "A");

            roadmap.AddPath("A", "B", 5);
            roadmap.AddPath("B", "A", 5);
            roadmap.Accept(visitor);
            Assert.Equal(10, visitor.ShortestDistance);

            roadmap.AddPath("A", "D", 1);
            roadmap.AddPath("D", "A", 1);
            roadmap.Accept(visitor);
            Assert.Equal(2, visitor.ShortestDistance);  
        }

        [Fact]
        public void should_get_trip_count_within_certain_distance()
        {
            var roadmap = new Roadmap();
            var visitor = new DistanceLimitRoadmapVisitor("A", "B", 5);
            roadmap.Accept(visitor);
            Assert.Equal(0, visitor.RouteCount);

            roadmap.AddPath("A", "B", 1);
            roadmap.AddPath("B", "A", 1);
            roadmap.AddPath("B", "C", 1);
            roadmap.AddPath("A", "C", 1);

            visitor = new DistanceLimitRoadmapVisitor("A", "C", 5);
            roadmap.Accept(visitor);
            Assert.Equal(4, visitor.RouteCount);

            visitor = new DistanceLimitRoadmapVisitor("A", "A", 5);
            roadmap.Accept(visitor);
            Assert.Equal(2, visitor.RouteCount);
        }
    }
}
