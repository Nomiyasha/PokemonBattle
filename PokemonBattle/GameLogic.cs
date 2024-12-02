using PokemonBattle.GUI;
using PokemonBattle.Enums;
using System.Numerics;
using PokemonBattle.Factories;

namespace PokemonBattle;

public class GameLogic
{

    private const string StartMenuTitle =
        "Welcome to Pokemon Battle! Use the arrow keys to navigate and press [ENTER] to select.";
    private readonly string[] _startMenuItems = {"Start Game", "Change Pokemon", "Exit Game"};
    
    private const string EndMenuTitle = "Game Over! You lost...";
    private readonly string[] _endMenuItems = {"Return to Start Menu"};
    
    private const string VictoryMenuTitle = "You won! Play again?";
    private readonly string[] _victoryMenuItems = { "Play again!", "Return to Start Menu" };
    
    private const string SelectPokemonMenuTitle = "Select a Pokemon!";
    private readonly string[] _selectPokemonMenuItems = { "Charmander", "Squirtle", "Bulbasaur" };

    private MenuUi StartMenu { get; }
    private MenuUi EndMenu { get; }
    private MenuUi VictoryMenu{ get; }
    private MenuUi SelectPokemonMenu{ get; set; }
    
    private Pokemon PlayerPokemon { get; set; }
    
    private PokemonFactory PokemonFactory { get; set; }

    private int _round;
    private const int StartLevel = 5;
    public GameLogic()
    {
        PokemonFactory = new PokemonFactory();
        PlayerPokemon = PokemonFactory.Create("Charmander", StartLevel); // Default pokemon
        
        StartMenu = new MenuUi(StartMenuTitle, _startMenuItems);
        EndMenu = new MenuUi(EndMenuTitle, _endMenuItems);
        VictoryMenu = new MenuUi(VictoryMenuTitle, _victoryMenuItems);
        SelectPokemonMenu = new MenuUi(SelectPokemonMenuTitle + $" Current Pokemon: {PlayerPokemon.Name}", 
            _selectPokemonMenuItems);

        _round = 1;

    }

    public void Run()
    {
        TitleScreenUi titleScreen = new TitleScreenUi();
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
                _round = 1;
                EndMenu.DisplayMenu();
                break;
            case 1: // Player won
                _round++;
                switch (VictoryMenu.DisplayMenu())
                {
                    case 0: // Play again!
                        BattleLoop(player);
                        break;
                    case 1: // Return To Main Menu
                        _round = 1;
                        break;
                }
                break;
        }
    }
    private Pokemon GenerateRandomPokemon()
    {
        return PokemonFactory.Random(_round); // Each round the enemy levels up.
    }
    private Pokemon ChoosePokemon()
    {
        Pokemon chosenPokemon = PlayerPokemon;
        
        switch (SelectPokemonMenu.DisplayMenu())
        {
            case 0: // Charmander
                chosenPokemon = PokemonFactory.Create("Charmander", StartLevel);
                break;
            case 1: // Squirtle
                chosenPokemon = PokemonFactory.Create("Squirtle", StartLevel);
                break;
            case 2: // Bulbasaur
                chosenPokemon = PokemonFactory.Create("Bulbasaur", StartLevel);
                break;
        }
        SelectPokemonMenu = new MenuUi(SelectPokemonMenuTitle + $" Current Pokemon: {chosenPokemon.Name}", 
            _selectPokemonMenuItems);
        
        return chosenPokemon;
    }




}