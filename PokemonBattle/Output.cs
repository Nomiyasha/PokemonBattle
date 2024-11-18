

using System.Runtime.CompilerServices;

namespace PokemonBattle;

public class Output
{
    public static void DisplayPokemons(Pokemon player, Pokemon enemy, string message)
    {
        Console.Clear();
        Console.WriteLine($"{player.Name}    vs    {enemy.Name}");
        Console.WriteLine($"{player.Hp}              {enemy.Hp}");
        Console.WriteLine("");
        Console.WriteLine($"{message}");
        
    }

    public static int InputMenu(IMove[] moves){
        int CursorPosLeft = Console.CursorLeft;
        int CursorPosTop = Console.CursorTop;
        int selected = 0;
        bool doneChoice = false;
        while(!doneChoice){
            Console.SetCursorPosition(CursorPosLeft,CursorPosTop);
            for(int i = 0; i < 4; i ++){
                if (selected == i){
                    Console.ForegroundColor = ConsoleColor.Green;
                    PrintMove(moves[i]);
                    Console.ResetColor();
                }else{
                    Console.ForegroundColor = ConsoleColor.Gray;
                    PrintMove(moves[i]);
                    Console.ResetColor();
                }
            }
            switch(Input.GetInput()){
                case 1:
                    selected++;
                    selected = selected%4;
                    break;
                case 2: 
                    selected--;
                    selected = (selected == -1) ? 3 : selected;
                    break;
                case 5:
                    doneChoice = true;
                    break;
            }

        }    
        return selected;
        
    }
    private static void PrintMove(IMove move){
        Console.WriteLine(move.Name);
        Console.WriteLine(" " + move.Description);

    }
}