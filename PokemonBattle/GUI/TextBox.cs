namespace PokemonBattle.GUI;

/// <summary>
/// A text box to be displayed on a SymbolGrid.
/// </summary>
public class TextBox
{
    

    public int Height { get; }
    public int Width { get; }
    
    public Position Position { get; }
    
    
    private Symbol[,] Content;
        
    
    private Symbol BorderUnselected
        => new Symbol('#', ConsoleColor.DarkBlue);
    
    private Symbol BorderSelected 
        => new Symbol('#', ConsoleColor.Blue);
    
    private string Title { get; }
    
    private string Description { get; }
    
    

    public TextBox(int width, int height, string title, string description, Position position)
    {
        Width = width;
        Height = height;
        Title = title;
        Description = description;
        Position = position;
        Content = new Symbol[Height, Width];
    }
    
    public TextBox(int width, int height, IMove move, Position position)
        :this(width, height, move.Name, move.Description, position) {}

    public void Draw(SymbolGrid grid, bool isSelected)
    {
        GenerateContent(isSelected);
        for (int y = Position.Y; y < Position.Y+Height; y++)
        {
            for (int x = Position.X; x < Position.X+Width; x++)
            {
                grid.DrawToGrid(Content[y-Position.Y, x-Position.X], new Position(x,y));
            }
        }
    }
    
    private void GenerateContent(bool isSelected)
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