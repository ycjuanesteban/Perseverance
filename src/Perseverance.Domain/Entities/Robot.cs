using Perseverance.Domain.Enums;

namespace Perseverance.Domain.Entities
{
    public class Robot
    {
        /// <summary>
        /// Robot current position
        /// </summary>
        public Coordinate CurrentPosition { get; private set; }

        /// <summary>
        /// Robot current camera direction
        /// </summary>
        public Direction Direction { get; private set; }

        /// <summary>
        /// Robot is lost
        /// </summary>
        public bool IsLost { get; private set; }

        /// <summary>
        /// Set of commands in format LRF
        /// </summary>
        public string SetOfCommands { get; private set; }

        /// <summary>
        /// Object of type <see cref="Mars"/> that represent the world
        /// </summary>
        public Mars Mars { get; private set; }


        public Robot(Coordinate initialCoordinate, Direction direction, string setOfCommands, Mars mars)
        {
            CurrentPosition = initialCoordinate;
            Direction = direction;
            Mars = mars;
            SetOfCommands = setOfCommands;
        }

        /// <summary>
        /// Execute the set of commands
        /// </summary>
        public void ExecuteComand()
        {
            foreach (char comand in SetOfCommands)
            {
                if (!IsLost)
                {
                    switch (comand)
                    {
                        case 'L':
                            TurnLeft();
                            break;

                        case 'R':
                            TurnRight();
                            break;

                        case 'F':
                            MoveForward();
                            break;

                        default:
                            // Exception
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Turn direction to left side
        /// </summary>
        private void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.W;
                    break;

                case Direction.S:
                    Direction = Direction.E;
                    break;

                case Direction.E:
                    Direction = Direction.N;
                    break;

                case Direction.W:
                    Direction = Direction.S;
                    break;
            }
        }

        /// <summary>
        /// Turn direction to right side
        /// </summary>
        private void TurnRight()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.E;
                    break;

                case Direction.S:
                    Direction = Direction.W;
                    break;

                case Direction.E:
                    Direction = Direction.S;
                    break;

                case Direction.W:
                    Direction = Direction.N;
                    break;
            }
        }

        /// <summary>
        /// Move forward the robot
        /// </summary>
        private void MoveForward()
        {
            Coordinate probablyNextPosition = SimuleNextPosition();

            if (!Mars.IsScenteThisPoint(probablyNextPosition))
            {
                if (RobotIsOut(probablyNextPosition))
                {
                    IsLost = true;
                    Mars.AddPointToScente(probablyNextPosition);
                }
                else
                {
                    CurrentPosition = new Coordinate(probablyNextPosition.X, probablyNextPosition.Y);
                }
            }
        }

        /// <summary>
        /// Recreate a posible new position to the robot
        /// </summary>
        /// <returns>return a new position</returns>
        private Coordinate SimuleNextPosition()
        {
            Coordinate coordinate;

            switch (Direction)
            {
                case Direction.N:
                    coordinate = new Coordinate(CurrentPosition.X + 1, CurrentPosition.Y);
                    break;
                case Direction.S:
                    coordinate = new Coordinate(CurrentPosition.X - 1, CurrentPosition.Y);
                    break;
                case Direction.E:
                    coordinate = new Coordinate(CurrentPosition.X, CurrentPosition.Y + 1);
                    break;
                case Direction.W:
                    coordinate = new Coordinate(CurrentPosition.X, CurrentPosition.Y - 1);
                    break;
                default:
                    coordinate = default;
                    break;
            }

            return coordinate;
        }

        /// <summary>
        /// Check if the posible new position is available
        /// </summary>
        /// <param name="coordinate">Object of type <see cref="Coordinate"/></param>
        /// <returns>True if the position is out of the mars limit, false in the other case</returns>
        private bool RobotIsOut(Coordinate coordinate)
        {
            return coordinate.X < 0 || coordinate.Y < 0
                    || Mars.XLimit < coordinate.X || Mars.YLimit < coordinate.Y;
        }

    }
}
