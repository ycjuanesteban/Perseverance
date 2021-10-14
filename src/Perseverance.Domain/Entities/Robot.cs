using Perseverance.Domain.Enums;

namespace Perseverance.Domain.Entities
{
    public class Robot
    {
        public Coordinate CurrentPosition { get; private set; }
        public Direction Direction { get; private set; }
        public bool IsLost { get; private set; }
        public string SetOfCommands { get; private set; }
        public Mars Mars { get; private set; }


        public Robot(Coordinate initialCoordinate, Direction direction, string setOfCommands, Mars mars)
        {
            CurrentPosition = initialCoordinate;
            Direction = direction;
            Mars = mars;
            SetOfCommands = setOfCommands;
        }

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

        private bool RobotIsOut(Coordinate coordinate)
        {
            return coordinate.X < 0 || coordinate.Y < 0
                    || Mars.XLimit < coordinate.X || Mars.YLimit < coordinate.Y;
        }

    }
}
