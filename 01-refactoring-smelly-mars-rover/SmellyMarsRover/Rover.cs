using System;

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
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rover)obj);
        }

        protected bool Equals(Rover other)
        {
            return Direction == other.Direction && _y == other._y && _x == other._x;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Direction, _y, _x);
        }

        public override string ToString()
        {
            return $"{nameof(Direction)}: {Direction}, {nameof(_y)}: {_y}, {nameof(_x)}: {_x}";
        }
    }
    internal record Direction(string Value);
}