using System.Runtime.CompilerServices;
using PokemonBattle.GUI;
using PokemonBattle.GUI.TextBoxes;
using PokemonBattle.Enums;

namespace PokemonBattle;
/// <summary>
/// Class for handling input and output during a pokemon battle
/// </summary>
public class BattleUI
{
    /// <summary>
    /// The width of one item in the UI
    /// </summary>
    private const int width = (int)Sizes.itemWidth;
    /// <summary>
    /// The height of on item in the UI
    /// </summary>
    private const int height = (int)Sizes.itemHeight;
    
    /// <summary>
    /// Generates a message that says what move a Pokemon did 
    /// </summary>
    /// <param name="pokemon">A Pokemon</param>
    /// <param name="move">A move</param>
    /// <returns>A string</returns>
    private string GenerateMessage(Pokemon pokemon, IMove move)
    { return $"{pokemon.Name} used {move.Name} \u25bc"; }

    /// <summary>
    /// Generates an instructional message
    /// </summary>
    /// <returns>A string</returns>
    private string GenerateMessage()
    { return $"Press enter to continue when this symbol appears: \u25bc"; }

    /// <summary>
    /// Displays the two pokemons involved in the battle as well as a message of what moves was used
    /// last turn by the opposing pokemon.
    /// </summary>
    /// <param name="player">Player pokemon</param>
    /// <param name="enemy">Enemy pokemon</param>
    /// <param name="turn">0 = player turn, 1 = enemy turn</param>
    /// <param name="moveIndex">What move was used</param>
    public void DisplayPokemonInfo(Pokemon player, Pokemon enemy, int turn, int moveIndex)
    {
        //Clear the console
        Console.Clear();
        //Initialize grid
        SymbolGrid grid = new SymbolGrid(height*3,width*2);
        string messageText = "";
        //Pokemon textboxes
        PokemonBox playerBox = new PokemonBox(width, (int)(height*2), player, new Position(0,0));
        PokemonBox enemyBox = new PokemonBox(width, (int)(height*2), enemy, new Position(width,0));
        
        //We display the instruction the first turn
        if(moveIndex == -1)
        { messageText = GenerateMessage(); }
        else{
            //On the player's turn we display what the enemy did, and vice versa
            if (turn == 0)
            { messageText = GenerateMessage(enemy, enemy.moves[moveIndex]); }
            else
            { messageText = GenerateMessage(player, player.moves[moveIndex]); }
            
        }
        //Message textboxe
        MessageBox message = new MessageBox(width*2,height, messageText, new Position(0,height*2));
        
        //Draw the textboxes to the grid
        playerBox.Draw(grid, false);
        enemyBox.Draw(grid, true);
        message.Draw(grid, false);
        
        //Write to the console
        grid.Display();
        
        Console.ReadKey(true);
    }
    /// <summary>
    /// A function for letting the user choose which move to use
    /// </summary>
    /// <param name="moves">The array of moves to choose from, max 4 moves</param>
    /// <returns>an index number of the chosen move from the array</returns>
    public int DisplayInputMenu(IMove[] moves){
        //For redrawing purposes, as console clear would clear other things on the console
        int cursorPosLeft = Console.CursorLeft;
        int cursorPosTop = Console.CursorTop;
        
        int[] selected = {0,0};
        int index = 0;
        bool doneChoice = false;
        //Initialize grid
        SymbolGrid menu = new SymbolGrid(height*2, width*2);
        //The list of textboxes
        MoveBox[] menuItems =
        {
           new MoveBox(width, height, moves[0],new Position(0,0)),
           new MoveBox(width, height, moves[1],new Position(width,0)),
           new MoveBox(width, height, moves[2],new Position(0,height)),
           new MoveBox(width, height, moves[3],new Position(width,height)),
        };
        //Drawing to the console and allowing interaction with the menu
        while(!doneChoice){
            Console.SetCursorPosition(cursorPosLeft,cursorPosTop);
            //Displaying the textboxes and which one is selected by the index
            for (int i = 0; i < menuItems.Length; i++)
            {
                //Calculating the 1d index from a 2d array
                index = (selected[1] *2) + selected[0];
                if (index == i)
                { menuItems[i].Draw(menu,true); }
                else
                { menuItems[i].Draw(menu,false); }
            }
            menu.Display();
            //Getting user input, ends the while loop when enter is pressed
            switch(Input.GetInput()){
                case 1:  // up
                    selected[1]--;
                    selected[1] = (selected[1] < 0) ? 0 : selected[1];
                    break;
                case 2: // down
                    selected[1]++;
                    selected[1] = (selected[1] > 1) ? 1 : selected[1];
                    break;
                case 3: // left
                    selected[0]--;
                    selected[0] = (selected[0] < 0) ? 0 : selected[0];
                    break;
                case 4: // right
                    selected[0]++;
                    selected[0] = (selected[0] > 1) ? 1 : selected[0];
                    break;
                case 5: // enter
                    doneChoice = true;
                    break;
            }

        }    
        return index;
    }
}