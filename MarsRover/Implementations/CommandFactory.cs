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
            return new NullCommand();
        }
    }
}
