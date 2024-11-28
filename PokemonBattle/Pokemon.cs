using PokemonBattle.Enums;
using PokemonBattle.Moves;

namespace PokemonBattle;

public class Pokemon
{
    public string Name { get; }
    public HealthStat Health { get; }
    public Level Level { get; }
    public bool IsAlive => Health.CurrentStat > 0;
    public AttackDefenceStat Attack { get; }
    public AttackDefenceStat Defence { get; }
    public Elements Type { get; }

    public List<IMove> moves = new List<IMove>();

    public Pokemon(string name, HealthStat health, Level level, AttackDefenceStat attack, AttackDefenceStat defence, List<IMove> moves, Elements type)
    {
        Name = name;
        Health = health;
        Level = level;
        Attack = attack;
        Defence = defence;
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
            // Checks for the case where health move is used against target (will attack and deal damage)
            // which is required for sending both user and target stats for this specific case
            if (typeof(HealthMove).IsInstanceOfType(move))
            {
                move.Use(this, target);
            }
            else
            {
                move.Use(target);
            }
        }
    }

    public void UpdateHealth(int change)
    {
        Health.UpdateStat(change);
    }
    
    public void UpdateAttack(int change)
    {
        Attack.UpdateStat(change);
    }

    public void UpdateDefence(int change)
    {
        Defence.UpdateStat(change);
    }

    public void ResetStats()
    {
        Health.ResetStat();
        Attack.ResetStat();
        Defence.ResetStat();
    }
}