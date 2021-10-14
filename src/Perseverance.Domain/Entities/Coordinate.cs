namespace Perseverance.Domain.Entities
{
    public class Coordinate
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y { get; private set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
