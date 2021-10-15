using Perseverance.Application.Utils;
using Perseverance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Perseverance.Application.Services
{
    public class PerseveranceService
    {
        /// <summary>
        /// 
        /// </summary>
        private RobotUtils _robotUtils;

        /// <summary>
        /// 
        /// </summary>
        private List<Robot> _robots;

        /// <summary>
        /// 
        /// </summary>
        private Mars _mars;

        public PerseveranceService(string fullInstructios)
        {
            if (string.IsNullOrEmpty(fullInstructios))
            {
                throw new ArgumentException($"{nameof(fullInstructios)} is empty");
            }

            _robotUtils = new RobotUtils(fullInstructios);

            SetUp();
        }

        /// <summary>
        /// Execute all the logic
        /// </summary>
        public void Execute()
        {
            foreach (var item in _robots)
            {
                item.ExecuteComand();
            }

            if (_mars.GetFinalScents().Count > 0)
            {
                _robotUtils.SaveRobotStatus(_mars);
            }
        }

        /// <summary>
        /// Get the list of the final robots state
        /// </summary>
        /// <returns></returns>
        public string[] GetFinalResult()
        {
            return _robots.Select(x => x.ToString()).ToArray();
        }

        /// <summary>
        /// Setup the world and robot list
        /// </summary>
        private void SetUp()
        {
            _mars = _robotUtils.GetWorld();
            _robots = _robotUtils.GetRobots();
        }

    }
}
