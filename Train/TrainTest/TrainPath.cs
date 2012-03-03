namespace TrainTest
{
    public class TrainPath
    {
        public const string NotExist = "NO SUCH ROUTE";
        public string Start { get; set; }
        public string End { get; private set; }
        public int Distance { get; private set; }

        public bool NeverRouted { get; set; }

        public TrainPath(string start, string end, int distance)
        {
            Start = start;
            End = end;
            Distance = distance;
            NeverRouted = true;
        }

        public bool Match(string start, string end)
        {
            return ComeFrom(start) && GoTo(end);
        }

        public bool Match(TrainPath path)
        {
            return Match(path.Start, path.End);
        }

        public bool ComeFrom(string start)
        {
            return Start == start;
        }

        public bool GoTo(string end)
        {
            return End == end;
        }

        public bool Connected(TrainPath next)
        {
            return GoTo(next.Start);
        }

        public void PassThrough()
        {
            NeverRouted = false;
        }

        public void Clear()
        {
            NeverRouted = true;
        }
    }
}