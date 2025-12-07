using System;

namespace SmellyMarsRover;

internal abstract record Direction
{
    private const string WEST = "W";
    private const string EAST = "E";
    private const string SOUTH = "S";
    private const string NORTH = "N";

    public static Direction Create(string directionEncoding)
    {
        if (directionEncoding.Equals(NORTH))
        {
            return CreateNorth();
        }

        if (directionEncoding.Equals(SOUTH))
        {
            return CreateSouth();
        }

        if (directionEncoding.Equals(WEST))
        {
            return CreateWest();
        }

        return CreateEast();
    }

    private static Direction CreateEast()
    {
        return new East();
    }

    private static Direction CreateWest()
    {
        return new West();
    }

    private static Direction CreateSouth()
    {
        return new South();
    }

    private static Direction CreateNorth()
    {
        return new North();
    }

    public abstract Direction RotateLeft();

    public abstract Direction RotateRight();

    public abstract Coordinates Move(Coordinates coordinates, int displacement);

    private record East : Direction
    {
        public override Direction RotateLeft()
        {
            return CreateNorth();
        }

        public override Direction RotateRight()
        {
            return CreateSouth();
        }

        public override Coordinates Move(Coordinates coordinates, int displacement)
        {
            return coordinates.MoveAlongXAxis(displacement);
        }
    }

    private record West : Direction
    {
        public override Direction RotateLeft()
        {
            return CreateSouth();
        }

        public override Direction RotateRight()
        {
            return CreateNorth();
        }

        public override Coordinates Move(Coordinates coordinates, int displacement)
        {
            return coordinates.MoveAlongXAxis(-displacement);
        }
    }

    private record South : Direction
    {
        public override Direction RotateLeft()
        {
            return CreateEast();
        }

        public override Direction RotateRight()
        {
            return CreateWest();
        }

        public override Coordinates Move(Coordinates coordinates, int displacement)
        {
            return coordinates.MoveAlongYAxis(-displacement);
        }
    }

    private record North : Direction
    {
        public override Direction RotateLeft()
        {
            return CreateWest();
        }

        public override Direction RotateRight()
        {
            return CreateEast();
        }

        public override Coordinates Move(Coordinates coordinates, int displacement)
        {
            return coordinates.MoveAlongYAxis(displacement);
        }
    }
}