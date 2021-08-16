using MarsRover.Constant;
using MarsRover.Entities;
using MarsRover.MoveMarsRover;
using MarsRover.Provider;
using MarsRover.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.MoveMarsRover
{
    public class MoveMarsRoverService : IMoveMarsRover
    {
        /// <summary>
        /// rover <paramref name="movement"/>
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="currentLocation"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        public Coordinates MoveRoverSync(string[] maxPoints, string[] currentLocation, string movement, Invoker _invoker)
        {
            var maxLst = new List<int>();
            foreach (var m in maxPoints)
            {
                var maxCoordinate = Convert.ToInt32(m);
                maxLst.Add(maxCoordinate);
            }
            var coordinates = new Coordinates();
            coordinates.X = Convert.ToInt32(currentLocation[0]);
            coordinates.Y = Convert.ToInt32(currentLocation[1]);
            coordinates.Dir = currentLocation[2].ToEnumValue<Directions>();
            Command command;

            foreach (var dir in movement)
            {
                switch (dir)
                {
                    case 'L':
                        MoveLeftTest ml= new MoveLeftTest();
                        command = (Command)ml;
                        break;
                    case 'R':
                        MoveRightTest mr = new MoveRightTest();
                        command = (Command)mr;
                        break;
                    case 'M':
                        MoveForwardTest mf = new MoveForwardTest();
                        command = (Command)mf;
                        break;

                    default:
                        return null;
                }
                var c = _invoker.StartMoving(command, coordinates);

                if (c == null)
                    return null;

                coordinates.Dir = c.Dir;
                coordinates.X = c.X;
                coordinates.Y = c.Y;
            }
            return coordinates;
        }
    }
}
