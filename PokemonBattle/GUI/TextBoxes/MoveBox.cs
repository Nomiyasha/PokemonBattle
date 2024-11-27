namespace PokemonBattle.GUI.TextBoxes;

public class MoveBox : TextBox
{
    protected override Symbol BorderUnselected
        => new Symbol(BorderChar, ConsoleColor.DarkGray);
    
    protected override Symbol BorderSelected 
        => new Symbol(BorderChar, ConsoleColor.White);
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="move">What move to display information about</param>
    /// <param name="position"></param>
    public MoveBox(int width, int height, IMove move, Position position)
        :base(width, height, move.Name, move.Description, position) {}
    
    /// <summary>
    /// Generates content to display
    /// </summary>
    /// <param name="isSelected">Changes both textcolor and bordercolor</param>
    protected override void GenerateContent(bool isSelected)
    {
        ConsoleColor color = ConsoleColor.White;
        if (isSelected)
        {
            color = ConsoleColor.White;
        }
        else
        {
            color = ConsoleColor.Gray;
        }
        
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (i == 0 || j == 0 || j == Width - 1 || i == Height - 1)
                {
                    Content[i, j] = (isSelected) ? BorderSelected : BorderUnselected;
                }
                else if (i == 1)
                {
                    try
                    {
                        Content[i, j] = new Symbol(Title[j-1], color);
                    }
                    catch
                    {
                        Content[i, j] = new Symbol(' ', color);
                        
                    }
                        
                }
                else
                {
                    
                    
                    try
                    {
                        Content[i, j] = new Symbol(Description[j-1], color);
                    }
                    catch
                    {
                        Content[i, j] = new Symbol(' ', color);
                    }
                }
            }
        }
        
    }
    
}