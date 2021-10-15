using System.Collections.Generic;

namespace Perseverance.Domain.Entities
{
    public class Mars
    {
        /// <summary>
        /// Max X size
        /// </summary>
        public int XLimit { get; private set; }

        /// <summary>
        /// Max Y size
        /// </summary>
        public int YLimit { get; private set; }

        /// <summary>
        /// List of scente points
        /// </summary>
        private List<Coordinate> _scentPoints { get; set; }

        public Mars(int xLimit, int yLimit)
        {
            XLimit = xLimit;
            YLimit = yLimit;
            _scentPoints = new List<Coordinate>();
        }

        /// <summary>
        /// Add new x,y point to the scente list
        /// </summary>
        /// <param name="coordinate"><see cref="Coordinate"/></param>
        public void AddPointToScente(Coordinate coordinate)
        {
            if (!_scentPoints.Contains(coordinate))
                _scentPoints.Add(coordinate);
        }

        /// <summary>
        /// Check if the x,y position exist already in the scent list
        /// </summary>
        /// <param name="coordinate"><see cref="Coordinate"/></param>
        /// <returns>True if position exist, false in the other case</returns>
        public bool IsScenteThisPoint(Coordinate coordinate)
        {
            return _scentPoints.Contains(coordinate);
        }

        /// <summary>
        /// Set the pre existents scents
        /// </summary>
        /// <param name="coordinates">List of type <see cref="Coordinate"/></param>
        public void SetPreexistentScents(List<Coordinate> coordinates)
        {
            _scentPoints = coordinates;
        }

        /// <summary>
        /// Return the list of scent points
        /// </summary>
        /// <returns></returns>
        public List<Coordinate> GetFinalScents()
        {
            return _scentPoints;
        }
    }
}
