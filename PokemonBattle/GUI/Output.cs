

using System.Runtime.CompilerServices;
using PokemonBattle.GUI;

namespace PokemonBattle;

public class Output
{

    private const int width = 28;
    private const int height = 4;
    public static void DisplayPokemons(Pokemon player, Pokemon enemy)
    {
        Console.Clear();
        Console.WriteLine($"{player.Name}    vs    {enemy.Name}");
        Console.WriteLine($"{player.Hp}              {enemy.Hp}");
        Console.WriteLine("");
    }

    private static string GenerateMessage(Pokemon pokemon, IMove move)
    {
        return $"{pokemon.Name} used {move.Name} ¤";
    }

    private static string GenerateMessage()
    {
        return $"Press enter to continue when this symbol appears ¤";
    }

    public static void DisplayMessage(Pokemon pokemon, int moveIndex){
        string messageText = "";
        SymbolGrid grid = new SymbolGrid(height,width*2);
        if(moveIndex == -1)
        {
            messageText = GenerateMessage();
        }else{
            messageText = GenerateMessage(pokemon, pokemon.moves[moveIndex]);
        }
        TextBox message = new TextBox(width*2,height,
            "<Use the arrow keys to select a move>", 
            messageText, new Position(0,0));
        message.Draw(grid, false);
        Console.CursorVisible = false;
        grid.Display();
        Console.CursorVisible = true;
        Console.ReadKey(true);
    }

    public static int DisplayInputMenu(IMove[] moves){
        int cursorPosLeft = Console.CursorLeft;
        int cursorPosTop = Console.CursorTop;
        int[] selected = {0,0};
        int index = 0;
        
        bool doneChoice = false;
        SymbolGrid menu = new SymbolGrid(height*2, width*2);
        TextBox[] menuItems =
        {
           new TextBox(width, height, moves[0],new Position(0,0)),
           new TextBox(width, height, moves[1],new Position(width,0)),
           new TextBox(width, height, moves[2],new Position(0,height)),
           new TextBox(width, height, moves[3],new Position(width,height)),
        };
        while(!doneChoice){
            Console.SetCursorPosition(cursorPosLeft,cursorPosTop);
            for (int i = 0; i < menuItems.Length; i++)
            {
                index = (selected[1] *2) + selected[0];
                if (index == i)
                {
                    menuItems[i].Draw(menu,true);
                }
                else
                {
                    menuItems[i].Draw(menu,false);
                }
            }
            Console.CursorVisible = false;
            menu.Display();
            Console.CursorVisible = true;
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
                case 5:
                    doneChoice = true;
                    break;
            }

        }    
        return index;
        
    }
}