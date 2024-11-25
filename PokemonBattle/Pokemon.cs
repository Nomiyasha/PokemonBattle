using PokemonBattle.Enums;

namespace PokemonBattle;

public class Pokemon
{
    public string Name { get; }
    public Stat Health { get; }
    public bool IsAlive => Health.CurrentStat > 0;
    public Stat Attack { get; }
    public Stat Defence { get; }
    public Elements Type { get; }

    public List<IMove> moves = new List<IMove>();

    public Pokemon(string name, Stat health, List<IMove> moves, Elements type)
    {
        Name = name;
        Health = health;
        this.moves = moves;
        Type = type;
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