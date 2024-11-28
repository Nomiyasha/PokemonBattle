namespace PokemonBattle.GUI.TextBoxes;

public class PokemonBox : TextBox
{
    protected override Symbol BorderUnselected
        => new Symbol(BorderChar, ConsoleColor.Red);
    
    protected override Symbol BorderSelected 
        => new Symbol(BorderChar, ConsoleColor.DarkRed);
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="pokemon">Pokemon to display information about, uses name and HP</param>
    /// <param name="position"></param>
    public PokemonBox(int width, int height, Pokemon pokemon, Position position)
        : base(width, height, pokemon.Name, pokemon.Health.CurrentStat.ToString(), position) { }
    
    
    /// <summary>
    /// Generates content to display
    /// </summary>
    /// <param name="isEnemy">Changes alignment of the text to the right side</param>
    protected override void GenerateContent(bool isEnemy)
    {
        ConsoleColor color = ConsoleColor.Red;
        int offset = 5; // 1 is 0 offset
        
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (i == 0 || j == 0 || j == Width - 1 || i == Height - 1)
                {
                    Content[i, j] = BorderSelected;
                }
                else if (i == 2)
                {
                    if (isEnemy)
                    {
                        try
                        {
                            Content[i, j] = new Symbol(Title[j - (Width - Title.Length)+offset], color);
                        }
                        catch
                        { Content[i, j] = new Symbol(' ', color); }
                    }
                    else
                    {
                        try
                        { Content[i, j] = new Symbol(Title[j-offset], color); }
                        catch
                        { Content[i, j] = new Symbol(' ', color); }
                    }
                }
                else if (i == 3)
                {
                    if (isEnemy)
                    {
                        try
                        { Content[i, j] = new Symbol(Description[j - (Width - Description.Length)+offset], color); }
                        catch
                        { Content[i, j] = new Symbol(' ', color); }
                    }
                    else
                    {
                        try
                        { Content[i, j] = new Symbol(Description[j-offset], color); }
                        catch
                        { Content[i, j] = new Symbol(' ', color); }
                    }
                }
                else
                { Content[i, j] = new Symbol(' ', color); }
            }
        }
        
    }
}