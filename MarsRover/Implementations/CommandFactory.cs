using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Contracts;

namespace MarsRover.Implementations
{
    public class CommandFactory
    {
        public ICommand Get(char command)
        {
            switch (command)
            {
                case 'F' :
                    return new Forward();
                case 'B' :
                    return new Reverse();
                case 'R' :
                    return new RotateRight();
                case 'L' :
                    return new RotateLeft();
                default:
                    return new NullCommand();
            }
        }
    }
}
