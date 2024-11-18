namespace PokemonBattle;

public class Input{
    enum Command
    {
        up = (int)ConsoleKey.UpArrow,
        down = (int)ConsoleKey.DownArrow,
        left = (int)ConsoleKey.LeftArrow,
        right = (int)ConsoleKey.RightArrow,
        enter = (int)ConsoleKey.Enter,
        esc = (int)ConsoleKey.Escape
    }

    public static int GetInput(){
        int choice = default;
        bool isCorrectInput = false;
        while(!isCorrectInput){
            Command input = (Command)Console.ReadKey(true).Key;
            switch(input){
                case Command.up:
                    choice = 1;
                    isCorrectInput = true;
                    break;
                case Command.down:
                    choice = 2;
                    isCorrectInput = true;
                    break;
                case Command.left:
                    choice = 3;
                    isCorrectInput = true;
                    break;
                case Command.right:
                    choice = 4;
                    isCorrectInput = true;
                    break;
                case Command.enter:
                    choice = 5;
                    isCorrectInput = true;
                    break;
                case Command.esc:
                    choice = 6;
                    isCorrectInput = true;
                    break;

            }
        }
        return choice;
        
    }
}