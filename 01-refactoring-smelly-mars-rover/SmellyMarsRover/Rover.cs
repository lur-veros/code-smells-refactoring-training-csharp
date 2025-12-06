using System;
using System.Collections.Generic;

namespace SmellyMarsRover
{
    public class Rover
    {        
        private Direction _direction;        
        private Coordinates _coordinates;

        public string Direction
        {
            set => _direction = new Direction(value);
        }

        public Rover(int x, int y, string direction)
        {
            Direction = direction;
            SetCoordinates(x, y);
        }

        private void SetCoordinates(int x, int y)
        {
            _coordinates = new Coordinates(x, y);
        }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                if (command.Equals("l"))
                {
                    // Rotate Rover to the left
                    if (_direction.IsFacingNorth())
                    {
                        Direction = "W";
                    }
                    else if (_direction.IsFacingSouth())
                    {
                        Direction = "E";
                    }
                    else if (_direction.IsFacingWest())
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
                    if (_direction.IsFacingNorth())
                    {
                        Direction = "E";                    
                    }
                    else if (_direction.IsFacingSouth())
                    {
                        Direction = "W";                      
                    }
                    else if (_direction.IsFacingWest())
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

                    if (_direction.IsFacingNorth())
                    {
                        _coordinates = _coordinates.MoveAlongYAxis(displacement);
                    }
                    else if (_direction.IsFacingSouth())
                    {
                        _coordinates = _coordinates.MoveAlongYAxis(-displacement);
                    }
                    else if (_direction.IsFacingWest())
                    {
                        _coordinates = _coordinates.MoveAlongXAxis(-displacement);
                    }
                    else
                    {
                        _coordinates = _coordinates.MoveAlongXAxis(displacement);
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Rover rover &&
                   EqualityComparer<Direction>.Default.Equals(_direction, rover._direction) &&
                   EqualityComparer<Coordinates>.Default.Equals(_coordinates, rover._coordinates);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_direction, _coordinates);
        }
    }
}