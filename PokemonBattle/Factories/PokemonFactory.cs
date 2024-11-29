using PokemonBattle.Enums;

namespace PokemonBattle;

public class PokemonFactory
{
    public Pokemon Create(string pokemonName, int level)
    {
        MoveFactory moveFactory = new MoveFactory();
        Level lvl = new Level(level);
        IMove[] charmanderMoveSet = [
            moveFactory.Create("ember"),
            moveFactory.Create("scratch"),
            moveFactory.Create("tailwhip"),
            moveFactory.Create("growl"),
        ];
        IMove[] squirtleMoveSet = [
            moveFactory.Create("watergun"),
            moveFactory.Create("tackle"),
            moveFactory.Create("tailwhip"),
            moveFactory.Create("withdraw"),
        ];
        IMove[] bulbasaurMoveSet = [
            moveFactory.Create("vinewhip"),
            moveFactory.Create("tackle"),
            moveFactory.Create("growl"),
            moveFactory.Create("growth"),
        ];
        
        
        
        return pokemonName.ToLower() switch
        {
            "charmander" => new Pokemon("Charmander", new HealthStat(50, lvl), lvl, 
                new AttackDefenceStat(77, lvl), new AttackDefenceStat(77, lvl), 
                charmanderMoveSet.ToList(), Elements.Fire),
            "squirtle" => new Pokemon("Squirtle", new HealthStat(50, lvl), lvl, 
                new AttackDefenceStat(77, lvl), new AttackDefenceStat(77, lvl), 
                squirtleMoveSet.ToList(), Elements.Water),
            "bulbasaur" => new Pokemon("Bulbasaur", new HealthStat(50, lvl), lvl, 
                new AttackDefenceStat(77, lvl), new AttackDefenceStat(77, lvl), 
                bulbasaurMoveSet.ToList(), Elements.Grass),
            _ => throw new ArgumentException("Invalid pokemonName")
        };
    }

    public Pokemon Random(int level)
    {
        Random random = new Random();
        string[] pokemonNames = ["charmander", "squirtle", "bulbasaur"];
        int randomIndex = random.Next(pokemonNames.Length);
        return Create(pokemonNames[randomIndex], level);
    }
}