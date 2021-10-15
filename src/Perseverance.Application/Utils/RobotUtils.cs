using Perseverance.Domain.Entities;
using Perseverance.Domain.Enums;
using Perseverance.Infrastructure.File.FileHandler;
using System;
using System.Collections.Generic;

namespace Perseverance.Application.Utils
{
    public class RobotUtils
    {

        /// <summary>
        /// Array of full user instructions
        /// </summary>
        private string[] _instructionsInLines;

        /// <summary>
        /// Object of type <see cref="Mars"/>
        /// </summary>
        private Mars _mars;

        private JSonHandler _jSonHandler;

        public RobotUtils(string userInstructions)
        {
            if (string.IsNullOrEmpty(userInstructions))
            {
                throw new ArgumentException($"{nameof(userInstructions)} is empty");
            }

            _instructionsInLines = userInstructions.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            _jSonHandler = new JSonHandler();
        }

        /// <summary>
        /// Create a instance of <see cref="Mars"/>
        /// </summary>
        /// <returns></returns>
        public Mars GetWorld()
        {
            string[] wordLimits = _instructionsInLines[0].Split(" ");

            int xLimit = Convert.ToInt32(wordLimits[0]);
            int yLimit = Convert.ToInt32(wordLimits[1]);

            _mars = new Mars(xLimit, yLimit);

            string fileName = $"{xLimit}{yLimit}";
            if (_jSonHandler.FileExist(fileName))
            {
                List<Coordinate> scentCoordinates = _jSonHandler.ReadFileData<List<Coordinate>>(fileName);
                _mars.SetPreexistentScents(scentCoordinates);
            }

            return _mars;
        }

        /// <summary>
        /// Create a list of type <see cref="Robot"/> that represent all the possible robots to execute
        /// </summary>
        /// <returns></returns>
        public List<Robot> GetRobots()
        {
            List<Robot> robots = new List<Robot>();
            List<string> robotInstructions = new List<string>();

            for (int i = 1; i < _instructionsInLines.Length; i++) //The first line is the world limits
            {
                /*
                 * 0 - 5 3 
                 * 1 - 1 1 E
                 * 2 - RFRFRFRF
                 */

                if (i % 2 == 0)
                {
                    if (_instructionsInLines[i].Length > 100)
                    {
                        throw new Exception("One of the instructions is bigger than 100 characters");
                    }

                    robotInstructions.Add(_instructionsInLines[i]);
                }
                else
                {
                    Coordinate coordinate = GetInitialCoordinate(_instructionsInLines[i]);
                    Direction direction = GetInitialDirection(_instructionsInLines[i]);

                    robots.Add(new Robot(coordinate, direction, _mars));
                }
            }

            //Join the instructions to each robot
            for (int i = 0; i < robots.Count; i++)
            {
                robots[i].SetCommands(robotInstructions[i]);
            }

            return robots;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mars"></param>
        public void SaveRobotStatus(Mars mars)
        {
            _jSonHandler.WriteFile($"{mars.XLimit}{mars.YLimit}", mars.GetFinalScents());
        }

        /// <summary>
        /// Setup the initial robot coordinate
        /// </summary>
        /// <param name="coordinate">Object of type <see cref="Coordinate"/></param>
        /// <returns></returns>
        private Coordinate GetInitialCoordinate(string coordinate)
        {
            string[] coordinateStrings = coordinate.Split(" ");
            int x = Convert.ToInt32(coordinateStrings[0]);
            int y = Convert.ToInt32(coordinateStrings[1]);

            return new Coordinate(x, y);
        }

        /// <summary>
        /// Create and object of type <see cref="Direction"/>
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private Direction GetInitialDirection(string coordinate)
        {
            Direction direction = default;
            string[] coordinateStrings = coordinate.Split(" ");

            switch (coordinateStrings[2])
            {
                case "N":
                    direction = Direction.N;
                    break;

                case "S":
                    direction = Direction.S;
                    break;

                case "E":
                    direction = Direction.E;
                    break;

                case "W":
                    direction = Direction.W;
                    break;
            }

            return direction;
        }
    }
}
