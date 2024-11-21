namespace PokemonBattle;

public class Symbol
{
    private char symbol;
    private ConsoleColor color;

    public Symbol(char symbol, ConsoleColor color)
    {
        this.symbol = symbol;
        this.color = color;
    }

    public void Draw()
    {
        Console.ForegroundColor = color;
        Console.Write(symbol);
        Console.ResetColor();
    }
}