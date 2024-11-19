namespace PokemonBattle;

public class Health : IMove
{
    public required bool IsSelfTarget { get; init; }
    public required string Name { get; init; }
    public required int Change { get; init; }
    public required string Description { get; init; }
    
    public void Use(Pokemon target)
    {
        target.UpdateHealth(Change);
    }
}