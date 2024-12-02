using PokemonBattle.Enums;
using PokemonBattle.Interfaces;
using PokemonBattle.Moves;

namespace PokemonBattle;

public class Pokemon
{
    public string Name { get; }
    public Level Level { get; }
    // KRAV 3
    // 1: Computed Properties
    // 2: Hur: Vi använder Computed Properties genom att ha en bool som räknas ut via andra medlemmar av klassen.
    // 3: Motivering: Det är rimligt att räkna på om Pokemonen lever eller ej varje gång man vill åt dess IsAlive status.
    public HealthStat Health { get; }
    public bool IsAlive => Health.CurrentStat > 0;
    public AttackDefenceStat Attack { get; }
    public AttackDefenceStat Defence { get; }
    public Elements Type { get; }
    // KRAV 4
    // 1: Objektkomposition
    // 2: Hur: En pokemon har en lista med moves(IMoves) den kan utföra. Se funktionen UseMove() vid rad 43 för del 2 av kravet.
    // 3: Motivering: Genom att ha en separat klass med moves så blir koden mer uppdelad i ansvarsområden samt lättare
    //    att hantera.
    public readonly List<IMove> Moves;

    // KRAV 5
    // 1: Beroendeinjektion
    // 2: Hur: En lista med moves (IMoves) injiceras i Pokemon klassen genom konstruktorn, m.a.o. Konstruktorinjektion. 
    //    Se funktionen UseMove() vid rad 43 för del 2 av kravet.
    // 3: Motivering: Genom att ha en separat klass med moves så blir koden mer uppdelad i ansvarsområden samt lättare
    //    att hantera. Samma motivering som Krav 4, men vi kraven blir väldigt sammanlänkade i denna klass.
    public Pokemon(string name, int health, int level, int attack, int defence, List<IMove> moves, Elements type)
    {
        Name = name;
        Level = new Level(level);
        Health = new HealthStat(health, Level);
        Attack = new AttackDefenceStat(attack, Level);
        Defence = new AttackDefenceStat(defence, Level);
        Moves = moves;
        Type = type;
    }

    public void UseMove(Pokemon target, int moveIndex)
    {
        IMove move = Moves[moveIndex];
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

    public void UpdateExp(int level)
    {
        Level.SetExp(level);
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