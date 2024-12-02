using PokemonBattle.Enums;
using PokemonBattle.Interfaces;

namespace PokemonBattle.Moves
{
    // KRAV 6
    // 1: Subtypspolymorfism 
    // 2: Hur: Den abstrakta klassen Move har 3 subtyper. Varje subtyp ärver minst en medlemsimplementation, denna
    //    implementation är algoritmiskt skiljd mellan subtyperna. Signaturen återfinns i subtypen. Signaturen(rna) 
    //    heter Use(Pokemon target) och Use(Pokemon target, Pokemon self), se rad 28 samt 29, se även subtypernas filer
    //    för implementationerna. Uppcasting finns i MoveFactory klassen, då behandlas olika moves som ett IMove.
    // 3: Det är det enklaste sättet att hantera att moves har olika funktionalitet men ska hanteras på samma sätt av
    //    en pokemon.
    public abstract class Move : IMove
    {
        public bool IsSelfTarget { get; }
        public int Change { get; }
        public Elements Type { get; }
        public string Name { get; }
        public string Description { get; }

        protected Move(bool isSelfTarget, int change, Elements type, string name, string description)
        {
            IsSelfTarget = isSelfTarget;
            Change = change; 
            Type = type; 
            Name = name; 
            Description = description;
        }

        public virtual void Use(Pokemon target) { }
        public virtual void Use(Pokemon user, Pokemon target) { }
    }
}
