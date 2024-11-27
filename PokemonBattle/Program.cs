namespace PokemonBattle;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        
        IMove[] moves = [
            new Health 
            {
                IsSelfTarget = false,
                Name = "Scratch",
                Change = -25,
                Description = "Attack"
            },
            new Health
            {
                IsSelfTarget = true,
                Name = "Heal",
                Change = 25,
                Description = "Healing"
            },
            new Health 
            {
                IsSelfTarget = false,
                Name = "Scratch",
                Change = -25,
                Description = "Healing"
            },
            new Health
            {
                IsSelfTarget = true,
                Name = "Heal",
                Change = 25,
                Description = "Healing"
            }
        ];
        
        Pokemon p = new Pokemon("Charizard", 220, moves.ToList());
        Pokemon enemy = new Pokemon("Squirtle", 120, moves.ToList());
        Battle battle = new Battle(p,enemy);
    }
}
