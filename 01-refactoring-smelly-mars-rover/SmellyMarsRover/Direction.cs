namespace SmellyMarsRover;

internal record Direction(string Value)
{
    public bool IsFacingNorth()
    {
        return this.Value.Equals("N");
    }

    public bool IsFacingSouth()
    {
        return this.Value.Equals("S");
    }

    public bool IsFacingWest()
    {
        return this.Value.Equals("W");
    }
}