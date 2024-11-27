using PokemonBattle.Enums;

namespace PokemonBattle;

class Program
{
    
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        MoveFactory factory = new MoveFactory();
        IMove[] moves = [
            factory.Create("ember"),
            factory.Create("scratch"),
            factory.Create("tailwhip"),
            factory.Create("growl"),
        ];
        
        Pokemon p = new Pokemon("Charmander", new HealthStat(50), moves.ToList(), Elements.Fire);
        Pokemon enemy = new Pokemon("Squirtle", new HealthStat(50), moves.ToList(), Elements.Grass);

        Battle battle = new Battle(p,enemy);
    }
}
