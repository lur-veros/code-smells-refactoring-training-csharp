namespace SmellyMarsRover;

internal record Direction(string Value)
{
    private const string WEST = "W";
    private const string EAST = "E";
    private const string SOUTH = "S";
    private const string NORTH = "N";

    public bool IsFacingNorth()
    {
        return this.Value.Equals(NORTH);
    }

    public bool IsFacingSouth()
    {
        return this.Value.Equals(SOUTH);
    }

    public bool IsFacingWest()
    {
        return this.Value.Equals(WEST);  
    }

    public static Direction Create(string value)
    {
        return new Direction(value);
    }

    public Direction RotateLeft()
    {
        Direction direction;
        if (IsFacingNorth())
        {
            direction = Create(WEST);
        }
        else if (IsFacingSouth())
        {
            direction = Create(EAST);
        }
        else if (IsFacingWest())
        {
            direction = Create(SOUTH);
        }
        else
        {
            direction = Create(NORTH);
        }

        return direction;
    }
}