using System.Collections.Generic;

namespace Perseverance.Domain.Entities
{
    public class Mars
    {
        public int XLimit { get; set; }
        public int YLimit { get; set; }

        private List<Coordinate> _scentePoints { get; set; }

        public Mars(int xLimit, int yLimit)
        {
            XLimit = xLimit;
            YLimit = yLimit;
            _scentePoints = new List<Coordinate>();
        }

        public void AddPointToScente(Coordinate coordinate)
        {
            if (!_scentePoints.Contains(coordinate))
                _scentePoints.Add(coordinate);
        }

        public bool IsScenteThisPoint(Coordinate coordinate)
        {
            return _scentePoints.Contains(coordinate);
        }
    }
}
