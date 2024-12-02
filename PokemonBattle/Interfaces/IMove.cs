namespace PokemonBattle.Interfaces;

public interface IMove
{
    bool IsSelfTarget { get; }
    string Name { get; }
    int Change { get; }
    string Description { get; }
    void Use(Pokemon target);
    void Use(Pokemon user, Pokemon target);
}