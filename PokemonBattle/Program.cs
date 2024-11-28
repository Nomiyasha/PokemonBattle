using PokemonBattle.Enums;
using PokemonBattle.GUI;

namespace PokemonBattle;

class Program
{
    
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Title = "Pokemon Battle";

        GameLogic gameLogic = new GameLogic();
        gameLogic.Run();
    }
}
