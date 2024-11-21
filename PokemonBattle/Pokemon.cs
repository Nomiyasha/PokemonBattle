using PokemonBattle.Enums;

namespace PokemonBattle;

public class Pokemon
{
    public string Name { get; }
    public int Hp { get; private set; }
    private int MaxHealth { get; }
    public bool IsAlive => Hp > 0;
    public int Attack { get; private set; }
    public int Defence { get; private set; }
    public Elements Type { get; }
    public string Message {get; private set;}

    public List<IMove> moves = new List<IMove>();

    public Pokemon(string name, int hp, List<IMove> moves, Elements type)
    {
        Name = name;
        Hp = hp;
        MaxHealth = hp;
        this.moves = moves;
        Type = type;
        Message = "";
    }

    public void UpdateMoves(IMove move)
    {
        if (moves.Count < 4)
        {
            moves.Add(move);
        } else
        {
            // Implement input logic to replace another move, or cancel replacements.
        }
    }

    public void UseMove(Pokemon target, int moveIndex)
    {
        IMove move = moves[moveIndex];
        if (move.IsSelfTarget)
        {
            move.Use(this);
        } else
        {
            move.Use(target);
        }
        this.Message = $"{Name} used {move.Name}";
    }

    public void UpdateHealth(int change)
    {
        Hp += Math.Max(0, change);
    }

    public void UpdateHealth(int change, Elements type)
    {
        if (ElementEffectiveness.Effectiveness.ContainsKey(type) && ElementEffectiveness.Effectiveness[type] == Type)
        {
            change -= 20;
        } else if (ElementEffectiveness.Weakness.ContainsKey(type) && ElementEffectiveness.Weakness[type] == Type)
        {
            change += 20;
        }
        
        Hp = Math.Max(0, Hp + change);
    }
 
    public void UpdateAttack(int change)
    {
        Attack += Math.Max(0, change);
    }

    public void UpdateDefence(int change)
    {
        Defence += Math.Max(0, change); 
    }
}