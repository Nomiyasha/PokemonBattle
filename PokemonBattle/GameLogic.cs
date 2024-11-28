using PokemonBattle.GUI;
using PokemonBattle.Enums;
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
    
    private const string selectPokemonMenuTitle = "Select a Pokemon";
    private readonly string[] selectPokemonMenuItems = { "Charmander", "Squirtle", "Bulbasaur" };

    private MenuUI StartMenu { get; }
    private MenuUI EndMenu { get; }
    private MenuUI VictoryMenu{ get; }
    private MenuUI SelectPokemonMenu{ get; }
    
    private Pokemon PlayerPokemon { get; set; }

    public GameLogic()
    {
        MoveFactory factory = new MoveFactory();
        IMove[] moves = [
            factory.Create("ember"),
            factory.Create("scratch"),
            factory.Create("tailwhip"),
            factory.Create("growl"),
        ];
        
        PlayerPokemon = new Pokemon("Charmander", new HealthStat(50), new AttackDefenceStat(77), new AttackDefenceStat(77), moves.ToList(), Elements.Fire);

        
        
        StartMenu = new MenuUI(startMenuTitle, startMenuItems);
        EndMenu = new MenuUI(endMenuTitle, endMenuItems);
        VictoryMenu = new MenuUI(victoryMenuTitle, victoryMenuItems);
        SelectPokemonMenu = new MenuUI(selectPokemonMenuTitle + $" Current Pokemon: {PlayerPokemon.Name}", selectPokemonMenuItems);
        
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
        Battle battle = new Battle(player, GenerateRandomPokemon());
        switch (battle.DoBattle())
        {
            case 0: // Player lost
                EndMenu.DisplayMenu();
                break;
            case 1: // Player won
                switch (VictoryMenu.DisplayMenu())
                {
                    case 0: // Play again!
                        BattleLoop(player);
                        break;
                    case 1: // Return To Main Menu
                        //Do nothing
                        break;
                }
                break;
        }
    }
    private Pokemon GenerateRandomPokemon()
    {
        MoveFactory factory = new MoveFactory();
        IMove[] moves = [
            factory.Create("ember"),
            factory.Create("scratch"),
            factory.Create("tailwhip"),
            factory.Create("growl"),
        ];
        return new Pokemon("Squirtle", new HealthStat(50), new AttackDefenceStat(77), new AttackDefenceStat(77), moves.ToList(), Elements.Grass);
    }
    private Pokemon ChoosePokemon()
    {
        Pokemon Current = PlayerPokemon;
        switch (SelectPokemonMenu.DisplayMenu())
        {
            case 1:
                Current = PlayerPokemon;
                break;
            case 2:
                Current = PlayerPokemon;
                break;
            case 3:
                Current = PlayerPokemon;
                break;
        }
        return Current;
    }




}