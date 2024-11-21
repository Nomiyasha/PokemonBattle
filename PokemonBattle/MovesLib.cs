using PokemonBattle.Enums;

namespace PokemonBattle
{
    public static class MovesLib
    {
        public static readonly Dictionary<string, Health> healthMoves = new()
        {
            { "Scratch", new Health 
                {
                    Name = "Scratch",
                    Description = "Do scratch.",
                    Type = Elements.Normal,
                    IsSelfTarget = false, 
                    Change = -25
                }
            }
        };

        public static readonly Dictionary<string, Health> attackMoves = new()
        {
            { "Sharpen", new Health 
                {
                    Name = "sharpen",
                    Description = "Sharpen stuff.",
                    Type = Elements.Normal,
                    IsSelfTarget = false, 
                    Change = 10
                }
            }
        };

        public static readonly Dictionary<string, Health> defenceMoves = new()
        {
            { "Stabilize", new Health 
                {
                    Name = "Stabilize",
                    Description = "Become stabilize.",
                    Type = Elements.Normal,
                    IsSelfTarget = false, 
                    Change = 25
                }
            }
        };
    }
}