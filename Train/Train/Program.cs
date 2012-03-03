using System;
using TrainTest;

namespace Train
{
    class Program
    {
        public static void Main()
        {
            //AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7
            var roadmap = new Roadmap();
            roadmap.AddPath("A", "B", 5);
            roadmap.AddPath("B", "C", 4);
            roadmap.AddPath("C", "D", 8);
            roadmap.AddPath("D", "C", 8);
            roadmap.AddPath("D", "E", 6);
            roadmap.AddPath("A", "D", 5);
            roadmap.AddPath("C", "E", 2);
            roadmap.AddPath("E", "B", 3);
            roadmap.AddPath("A", "E", 7);

            var roadmapWalker = new RoadmapWalker(roadmap);

            var calculateDistance = roadmapWalker.CalculateDistance("A", "B", "C");
            Console.WriteLine(calculateDistance);

            calculateDistance = roadmapWalker.CalculateDistance("A", "D");
            Console.WriteLine(calculateDistance);
            
            calculateDistance = roadmapWalker.CalculateDistance("A", "D", "C");
            Console.WriteLine(calculateDistance);
            
            calculateDistance = roadmapWalker.CalculateDistance("A", "E", "B", "C", "D");
            Console.WriteLine(calculateDistance);
            
            calculateDistance = roadmapWalker.CalculateDistance("A", "E", "D");
            Console.WriteLine(calculateDistance);

            var tripCountWithMaxStops = roadmapWalker.TripCountWithMaxStops("C", "C", 3);
            Console.WriteLine(tripCountWithMaxStops);

            var tripCountWithFixStops = roadmapWalker.TripCountWithFixStops("A", "C", 4);
            Console.WriteLine(tripCountWithFixStops);

            var shortestPath = roadmapWalker.ShortestPath("A", "C");
            Console.WriteLine(shortestPath);
            
            shortestPath = roadmapWalker.ShortestPath("B", "B");
            Console.WriteLine(shortestPath);

            var tripCountLessThanDistance = roadmapWalker.TripCountLessThanDistance("C", "C", 30);
            Console.WriteLine(tripCountLessThanDistance);

            Console.ReadLine();
        }
    }
}
