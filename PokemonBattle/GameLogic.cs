using PokemonBattle.GUI;
using PokemonBattle.Enums;
using System.Numerics;
namespace PokemonBattle;

public class GameLogic
{

    private const string startMenuTitle =
        "Welcome to Pokemon Battle! Use the arrow keys to navigate and press [ENTER] to select.";
    private readonly string[] startMenuItems = {"Start Game", "Change Pokemon", "Exit Game"};
    
    private const string endMenuTitle = "Game Over! You lost...";
    private readonly string[] endMenuItems = {"Return to Start Menu"};
    
    private const string victoryMenuTitle = "You won! Play again?";
    private readonly string[] victoryMenuItems = { "Play again!", "Return to Start Menu" };
    
    private const string selectPokemonMenuTitle = "Select a Pokemon!";
    private readonly string[] selectPokemonMenuItems = { "Charmander", "Squirtle", "Bulbasaur" };

    private MenuUI StartMenu { get; }
    private MenuUI EndMenu { get; }
    private MenuUI VictoryMenu{ get; }
    private MenuUI SelectPokemonMenu{ get; set; }
    
    private Pokemon PlayerPokemon { get; set; }
    
    private PokemonFactory PokemonFactory { get; set; }

    private int round;
    private const int startLevel = 5;
    public GameLogic()
    {
        PokemonFactory = new PokemonFactory();
        PlayerPokemon = PokemonFactory.Create("Charmander", startLevel); // Default pokemon
        
        StartMenu = new MenuUI(startMenuTitle, startMenuItems);
        EndMenu = new MenuUI(endMenuTitle, endMenuItems);
        VictoryMenu = new MenuUI(victoryMenuTitle, victoryMenuItems);
        SelectPokemonMenu = new MenuUI(selectPokemonMenuTitle + $" Current Pokemon: {PlayerPokemon.Name}", 
            selectPokemonMenuItems);

        round = 1;

    }

    public void Run()
    {
        TitleScreenUI titleScreen = new TitleScreenUI();
        titleScreen.Display();
        
        bool isRunning = true;
        while (isRunning)
        {
            switch (StartMenu.DisplayMenu())
            {
                case 0:
                    BattleLoop(PlayerPokemon);
                    break;
                case 1:
                    PlayerPokemon = ChoosePokemon();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\n\tSee you next time!");
                    isRunning = false;
                    break;
            }
        }
        
        
        
    }

    private void BattleLoop(Pokemon player)
    {
        player.ResetStats();
        Battle battle = new Battle(player, GenerateRandomPokemon());
        switch (battle.DoBattle())
        {
            case 0: // Player lost
                round = 1;
                EndMenu.DisplayMenu();
                break;
            case 1: // Player won
                round++;
                switch (VictoryMenu.DisplayMenu())
                {
                    case 0: // Play again!
                        BattleLoop(player);
                        break;
                    case 1: // Return To Main Menu
                        round = 1;
                        break;
                }
                break;
        }
    }
    private Pokemon GenerateRandomPokemon()
    {
        return PokemonFactory.Random(round); // Each round the enemy levels up.
    }
    private Pokemon ChoosePokemon()
    {
        Pokemon chosenPokemon = PlayerPokemon;
        
        switch (SelectPokemonMenu.DisplayMenu())
        {
            case 0: // Charmander
                chosenPokemon = PokemonFactory.Create("Charmander", startLevel);
                break;
            case 1: // Squirtle
                chosenPokemon = PokemonFactory.Create("Squirtle", startLevel);
                break;
            case 2: // Bulbasaur
                chosenPokemon = PokemonFactory.Create("Bulbasaur", startLevel);
                break;
        }
        SelectPokemonMenu = new MenuUI(selectPokemonMenuTitle + $" Current Pokemon: {chosenPokemon.Name}", 
            selectPokemonMenuItems);
        
        return chosenPokemon;
    }




}