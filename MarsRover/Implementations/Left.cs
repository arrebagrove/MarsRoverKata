using MarsRover.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Implementations
{
    public class Left : ICommand
    {
        private int _turnRightBy = 2;

        public int CommandValue
        {
            get
            {
                return _turnRightBy;
            }
        }
    }
}
