namespace PokemonBattle;

public class Battle
{
    private Pokemon Player { get; }
    private Pokemon Enemy { get; }
    public Battle(Pokemon player, Pokemon enemy)
    {
        Player = player;
        Enemy = enemy;

        DoBattle();
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
                enemymove = 0; // random?
                Enemy.UseMove(Player, enemymove);
            }

            turnIndex++;
        }

        return (Player.IsAlive) ? 1 : 0;
    }
}
