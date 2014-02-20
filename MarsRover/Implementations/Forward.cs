using MarsRover.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Implementations
{
    public class Forward : ICommand
    {
        private readonly int _forwardsOrBackwards = 1;
        
        public int ForwardsOrBackwards
        {
            get
            {
                return _forwardsOrBackwards;
            }
        }

    }
}
