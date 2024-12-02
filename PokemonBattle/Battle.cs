namespace PokemonBattle;

public class Battle
{
    private Pokemon Player { get; }
    private Pokemon Enemy { get; }
    private readonly Random random = new Random();
    public Battle(Pokemon player, Pokemon enemy)
    {
        Player = player;
        Enemy = enemy;
    }

    public int DoBattle()
    {
        int playermove = -1;
        int enemymove = -1;
        int turnIndex = 0;
        BattleUI UI = new BattleUI();

        while (Player.IsAlive && Enemy.IsAlive)
        {
            if (turnIndex == 2)
            {
                turnIndex = 0;
            }

            if (turnIndex == 0)
            {

                UI.DisplayPokemonInfo(Player, Enemy, turnIndex, enemymove);
                playermove = UI.DisplayInputMenu(Player.moves.ToArray()); // input
                Player.UseMove(Enemy, playermove);
            }
            else
            {
                UI.DisplayPokemonInfo(Player, Enemy, turnIndex, playermove);
                enemymove = random.Next(0, Enemy.moves.Count - 1);
                Enemy.UseMove(Player, enemymove);
            }

            turnIndex++;
        }
        // Display one last time, else people won't know what hit them.
        if (turnIndex == 0)
        {
            UI.DisplayPokemonInfo(Player, Enemy, turnIndex, enemymove);
        }
        else
        {
            UI.DisplayPokemonInfo(Player, Enemy, turnIndex, playermove);
        }
        if (Player.IsAlive) Player.UpdateExp(Enemy.Level.CurrentLevel);
        return (Player.IsAlive) ? 1 : 0;
    }
}
