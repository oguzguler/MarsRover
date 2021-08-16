using MarsRover.Entities;
using MarsRover.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.MoveMarsRover
{
    interface IMoveMarsRover
    {
        Coordinates MoveRoverSync(string[] maxPoints, string[] currentLocation, string movement, Invoker _invoker);
    }

}
