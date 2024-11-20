using PokemonBattle.Enums;

namespace PokemonBattle;

public class Health : IMove
{
    public required bool IsSelfTarget { get; init; }
    public required string Name { get; init; }
    public required int Change { get; init; }
    public required string Description { get; init; }
    public required Elements Type { get; init; }
    
    public void Use(Pokemon target)
    {
        if (Type == Elements.None)
        {
            target.UpdateHealth(Change);
        }
        else
        {
            target.UpdateHealth(Change, Type);
        }
    }
}