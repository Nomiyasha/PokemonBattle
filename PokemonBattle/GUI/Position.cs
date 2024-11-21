namespace PokemonBattle.GUI;

public class Position
{
    public int X {get; set;}
    public int Y {get; set;}

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public Position(Position other)
    {
        X = other.X;
        Y = other.Y;
    }

}