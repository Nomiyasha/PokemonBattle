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
        int playermove = -1;
        int enemymove = -1;
        int turnIndex = 0;
        while (Player.IsAlive && Enemy.IsAlive)
        {
            
            if (turnIndex == 2){turnIndex = 0;}
            
            if(turnIndex == 0){
                
                Output.DisplayPokemons(Player,Enemy);
                Output.DisplayMessage(Enemy, enemymove); //display last move that happened
                playermove = Output.DisplayInputMenu(Player.moves.ToArray()); // input
                Player.Attack(Enemy, playermove);
                
                
            }
            else
            {

                Output.DisplayPokemons(Player,Enemy);
                Output.DisplayMessage(Player,playermove); // display last move happened
                enemymove = 0; // random?
                Enemy.Attack(Player, enemymove);
            }
            turnIndex++;
        }
        Console.WriteLine("Battle over");
    }
}
