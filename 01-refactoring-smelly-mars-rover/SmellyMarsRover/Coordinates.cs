namespace SmellyMarsRover;

internal record Coordinates(int X, int Y)
{
    public Coordinates MoveAlongYAxis(int displacement)
    {
        return new Coordinates(this.X, this.Y + displacement);
    }

    public Coordinates MoveAlongXAxis(int displacement)
    {
        return new Coordinates(this.X + displacement, this.Y);
    }
}