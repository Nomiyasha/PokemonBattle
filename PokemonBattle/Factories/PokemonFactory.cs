using PokemonBattle.Enums;

namespace PokemonBattle;

public class PokemonFactory
{
    public Pokemon Create(string pokemonName, int level)
    {
        MoveFactory moveFactory = new MoveFactory();
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
            "charmander" => new Pokemon("Charmander", 50, level, 
                77, 77, charmanderMoveSet.ToList(), Elements.Fire),
            "squirtle" => new Pokemon("Squirtle", 50, level,
                77, 77, squirtleMoveSet.ToList(), Elements.Water),
            "bulbasaur" => new Pokemon("Bulbasaur", 50, level,
                77, 77, bulbasaurMoveSet.ToList(), Elements.Grass),
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