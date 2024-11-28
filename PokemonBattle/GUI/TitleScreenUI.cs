﻿namespace PokemonBattle.GUI;
/// <summary>
/// Class for displaying the title screen
/// </summary>
public class TitleScreenUI
{
    private const string title = """
                                         ______ _____ _   __ ________  ________ _   _ 
                                         | ___ \  _  | | / /|  ___|  \/  |  _  | \ | |
                                         | |_/ / | | | |/ / | |__ | .  . | | | |  \| |
                                         |  __/| | | |    \ |  __|| |\/| | | | | . ` |
                                         | |   \ \_/ / |\  \| |___| |  | \ \_/ / |\  |
                                         \_|    \___/\_| \_/\____/\_|  |_/\___/\_| \_/
                                                                                      
                                                                                      
                                             ______  ___ _____ _____ _      _____         
                                             | ___ \/ _ \_   _|_   _| |    |  ___|        
                                             | |_/ / /_\ \| |   | | | |    | |__          
                                             | ___ \  _  || |   | | | |    |  __|         
                                             | |_/ / | | || |   | | | |____| |___         
                                             \____/\_| |_/\_/   \_/ \_____/\____/         
                                                                                      
                                                                                      
                                         """;
    private const string titleMessage = "\tPress [ENTER] to start";
    /// <summary>
    /// Print the title to the console
    /// </summary>
    public void Display()
    {
        Console.WriteLine(title);
        Console.Write(titleMessage);
        Console.ReadKey(true);
    }
}