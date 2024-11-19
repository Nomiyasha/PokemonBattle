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

    public void DoBattle()
    {
        int playermove = default;
        int turnIndex = 0;
        while (Player.IsAlive && Enemy.IsAlive)
        {
            
            if (turnIndex == 2){turnIndex = 0;}
            
            if(turnIndex == 0){
                Player.UseMove(Enemy, playermove);
                Output.DisplayPokemons(Player,Enemy, Player.Message);
                playermove = Output.InputMenu(Player.moves.ToArray()); // input
                
                
            }
            else
            {
                Output.DisplayPokemons(Player,Enemy, Enemy.Message);
                 int enemymove = 0; // random?
                 Console.WriteLine("Enemy thinking...");
                 Thread.Sleep(500);
                 Enemy.UseMove(Player, enemymove);
            }
            turnIndex++;
        }
        Console.WriteLine("Battle over");
    }
}
