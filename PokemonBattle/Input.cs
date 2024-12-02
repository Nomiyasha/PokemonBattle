namespace PokemonBattle;

public class Input{
    enum Command
    {
        Up = (int)ConsoleKey.UpArrow,
        Down = (int)ConsoleKey.DownArrow,
        Left = (int)ConsoleKey.LeftArrow,
        Right = (int)ConsoleKey.RightArrow,
        Enter = (int)ConsoleKey.Enter
        
    }

    public static int GetInput(){
        int choice = default;
        bool isCorrectInput = false;
        while(!isCorrectInput){
            Command input = (Command)Console.ReadKey(true).Key;
            switch(input){
                case Command.Up:
                    choice = 1;
                    isCorrectInput = true;
                    break;
                case Command.Down:
                    choice = 2;
                    isCorrectInput = true;
                    break;
                case Command.Left:
                    choice = 3;
                    isCorrectInput = true;
                    break;
                case Command.Right:
                    choice = 4;
                    isCorrectInput = true;
                    break;
                case Command.Enter:
                    choice = 5;
                    isCorrectInput = true;
                    break;
            }
        }
        return choice;
        
    }
}