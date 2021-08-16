using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Entities;
using MarsRover.Provider;

namespace MarsRover.ActionInvoker
{
    public class ExecuteAction : Invoker
    {
        /// <summary>
        /// start movement of rover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Coordinates StartMoving(Command command, Coordinates coordinates)
        {
            return command.Execute(coordinates);
        }
    }
}
