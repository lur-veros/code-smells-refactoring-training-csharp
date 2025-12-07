using System;
using System.Collections.Generic;

namespace SmellyMarsRover
{
    public class Rover
    {        
        private Direction _direction;        
        private Coordinates _coordinates;

        public Rover(int x, int y, string direction)
        {
            _direction = SmellyMarsRover.Direction.Create(direction);
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
                    _direction = _direction.RotateLeft();
                }
                else if (command.Equals("r"))
                {
                    _direction = _direction.RotateRight();
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

                    Coordinates coordinates = _coordinates;
                    coordinates = _direction.Move(coordinates, displacement, this);

                    _coordinates = coordinates;
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