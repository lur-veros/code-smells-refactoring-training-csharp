using System;
using System.Collections.Generic;

namespace SmellyMarsRover
{
    public class Rover
    {
        private string _direction;
        private Direction _directionType;
        private int _y;
        private int _x;        

        public string Direction 
        { 
            get => _direction; 
            set
            {
                _direction = value;
                _directionType = new Direction(value);
            } 
        }

        public Rover(int x, int y, string direction)
        {
            Direction = direction;
            _y = y;
            _x = x;
        }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                if (command.Equals("l"))
                {
                    // Rotate Rover to the left
                    if (Direction.Equals("N"))
                    {
                        Direction = "W";                     
                    }
                    else if (Direction.Equals("S"))
                    {
                        Direction = "E";
                    }
                    else if (Direction.Equals("W"))
                    {
                        Direction = "S";
                    }
                    else
                    {
                        Direction = "N";                     
                    }
                }
                else if (command.Equals("r"))
                {
                    // Rotate Rover to the right
                    if (Direction.Equals("N"))
                    {
                        Direction = "E";                    
                    }
                    else if (Direction.Equals("S"))
                    {
                        Direction = "W";                      
                    }
                    else if (Direction.Equals("W"))
                    {
                        Direction = "N";                      
                    }
                    else
                    {
                        Direction = "S";                     
                    }
                }
                else
                {
                    // Displace Rover
                    var displacement1 = -1;

                    if (command.Equals("f"))
                    {
                        displacement1 = 1;
                    }

                    var displacement = displacement1;

                    if (Direction.Equals("N"))
                    {
                        _y += displacement;
                    }
                    else if (Direction.Equals("S"))
                    {
                        _y -= displacement;
                    }
                    else if (Direction.Equals("W"))
                    {
                        _x -= displacement;
                    }
                    else
                    {
                        _x += displacement;
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Rover rover &&
                   EqualityComparer<Direction>.Default.Equals(_directionType, rover._directionType) &&
                   _y == rover._y &&
                   _x == rover._x;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_directionType, _y, _x);
        }
    }

    internal record Direction(string Value);
}