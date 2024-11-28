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
        Level lv5 = new Level(5);
        Level lv10 = new Level(10);
        Pokemon p = new Pokemon("Charmander", new HealthStat(50, lv10), lv10, new AttackDefenceStat(48, lv10), new AttackDefenceStat(48, lv10), moves.ToList(), Elements.Fire);
        Pokemon enemy = new Pokemon("Squirtle", new HealthStat(50, lv5), lv5, new AttackDefenceStat(48, lv5), new AttackDefenceStat(48, lv5), moves.ToList(), Elements.Grass);

        Battle battle = new Battle(p,enemy);
    }
}
