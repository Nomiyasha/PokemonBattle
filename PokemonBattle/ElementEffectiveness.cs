using PokemonBattle.Enums;

namespace PokemonBattle
{
    public static class ElementEffectiveness
    {
        public static readonly Dictionary<Elements, Elements> Weakness = new()
        {
            { Elements.Fire, Elements.Water },
            { Elements.Water, Elements.Grass },
            { Elements.Grass, Elements.Fire }
        };

        public static readonly Dictionary<Elements, Elements> Effectiveness = new()
        {
            { Elements.Grass, Elements.Water },
            { Elements.Fire, Elements.Grass },
            { Elements.Water, Elements.Fire }
        };
    }
}
