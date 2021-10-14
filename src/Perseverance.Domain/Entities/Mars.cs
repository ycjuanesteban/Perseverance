using System.Collections.Generic;

namespace Perseverance.Domain.Entities
{
    public class Mars
    {
        /// <summary>
        /// Max X size
        /// </summary>
        public int XLimit { get; set; }

        /// <summary>
        /// Max Y size
        /// </summary>
        public int YLimit { get; set; }

        /// <summary>
        /// List of scente points
        /// </summary>
        private List<Coordinate> _scentePoints { get; set; }

        public Mars(int xLimit, int yLimit)
        {
            XLimit = xLimit;
            YLimit = yLimit;
            _scentePoints = new List<Coordinate>();
        }

        /// <summary>
        /// Add new x,y point to the scente list
        /// </summary>
        /// <param name="coordinate"><see cref="Coordinate"/></param>
        public void AddPointToScente(Coordinate coordinate)
        {
            if (!_scentePoints.Contains(coordinate))
                _scentePoints.Add(coordinate);
        }

        /// <summary>
        /// Check if the x,y position exist already in the scent list
        /// </summary>
        /// <param name="coordinate"><see cref="Coordinate"/></param>
        /// <returns>True if position exist, false in the other case</returns>
        public bool IsScenteThisPoint(Coordinate coordinate)
        {
            return _scentePoints.Contains(coordinate);
        }
    }
}
