using PokemonBattle.Enums;

namespace PokemonBattle
{
    class MovesLib
    {
        Dictionary<string, Health> healthMoves = new()
        {
            { "Scratch", new Health 
                {
                    IsSelfTarget = false, 
                    Name = "Scratch",
                    Change = -25,
                    Description = "Do scratch.",
                    Type = Elements.Normal
                }
            }
        };
    }
}