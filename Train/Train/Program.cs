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
            roadmap.AddPath(new TrainPath("A", "B", 5));
            roadmap.AddPath(new TrainPath("B", "C", 4));
            roadmap.AddPath(new TrainPath("C", "D", 8));
            roadmap.AddPath(new TrainPath("D", "C", 8));
            roadmap.AddPath(new TrainPath("D", "E", 6));
            roadmap.AddPath(new TrainPath("A", "D", 5));
            roadmap.AddPath(new TrainPath("C", "E", 2));
            roadmap.AddPath(new TrainPath("E", "B", 3));
            roadmap.AddPath(new TrainPath("A", "E", 7));

            var calculateDistance = roadmap.CalculateDistance("A", "B", "C");
            Console.WriteLine(calculateDistance);
            calculateDistance = roadmap.CalculateDistance("A", "D");
            Console.WriteLine(calculateDistance);
            calculateDistance = roadmap.CalculateDistance("A", "D", "C");
            Console.WriteLine(calculateDistance);
            calculateDistance = roadmap.CalculateDistance("A", "E", "B", "C", "D");
            Console.WriteLine(calculateDistance);
            calculateDistance = roadmap.CalculateDistance("A", "E", "D");
            Console.WriteLine(calculateDistance);

            var tripCountWithMaxStops = roadmap.TripCountWithMaxStops("C", "C", 3);
            Console.WriteLine(tripCountWithMaxStops);

            var tripCountWithFixStops = roadmap.TripCountWithFixStops("A", "C", 4);
            Console.WriteLine(tripCountWithFixStops);

            var shortestPath = roadmap.ShortestPath("A", "C");
            Console.WriteLine(shortestPath);
            shortestPath = roadmap.ShortestPath("B", "B");
            Console.WriteLine(shortestPath);

            var tripCountLessThanDistance = roadmap.TripCountLessThanDistance("C", "C", 30);
            Console.WriteLine(tripCountLessThanDistance);

            Console.ReadLine();
        }
    }
}
