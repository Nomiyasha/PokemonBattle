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

        public static readonly Dictionary<string, Attack> attackMoves = new()
        {
            { "Sharpen", new Attack 
                {
                    Name = "sharpen",
                    Description = "Sharpen stuff.",
                    IsSelfTarget = false, 
                    Change = 10
                }
            }
        };

        public static readonly Dictionary<string, Defence> defenceMoves = new()
        {
            { "Stabilize", new Defence 
                {
                    Name = "Stabilize",
                    Description = "Become stabilize.",
                    IsSelfTarget = false, 
                    Change = 25
                }
            }
        };
    }
}