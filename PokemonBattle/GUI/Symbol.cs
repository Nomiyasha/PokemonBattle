namespace PokemonBattle.GUI;

public class Symbol
{
    private readonly char _symbol;
    private readonly ConsoleColor _color;

    public Symbol(char symbol, ConsoleColor color)
    {
        this._symbol = symbol;
        this._color = color;
    }
    // KRAV 2
    // 1: Overloading av konstruktorer
    // 2: Hur: vi har en konstruktor som tar emot en consolecolor, samt en konstruktor som inte gör det och sätter
    //    fältet color till vitt.
    // 3: Motivering: Minska kodduplikation där Symbol används. 
    public Symbol(char symbol)
    {
        this._symbol = symbol;
        _color = ConsoleColor.White;
    }

    public void Draw()
    {
        Console.ForegroundColor = _color;
        Console.Write(_symbol);
        Console.ResetColor();
    }
}