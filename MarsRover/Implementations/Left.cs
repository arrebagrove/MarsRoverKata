using MarsRover.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Implementations
{
    public class Left : ICommand, IRotate
    {
        private int _turnLeftBy = -2;

        public int CommandValue
        {
            get
            {
                return _turnLeftBy;
            }
        }
    }
}
