namespace PokemonBattle;

public interface IMove
{
    bool IsSelfTarget { get; }
    string Name { get; }
    int Change { get; }
    string Description { get; }
    void Use(Pokemon target);
}