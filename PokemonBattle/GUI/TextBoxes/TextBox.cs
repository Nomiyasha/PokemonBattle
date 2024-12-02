namespace PokemonBattle.GUI.TextBoxes;

/// <summary>
/// A text box to be displayed on a SymbolGrid.
/// </summary>
public abstract class TextBox
{
    
    /// <summary>
    /// Height of the textbox
    /// </summary>
    protected int Height { get; }
    /// <summary>
    /// Width of the textbox
    /// </summary>
    protected int Width { get; }
    /// <summary>
    /// Position of the top left corner of the textbox
    /// </summary>
    private Position Position { get; }
    
    /// <summary>
    /// The content of the textbox
    /// </summary>
    protected readonly Symbol[,] Content;

    /// <summary>
    /// The character to use for the border
    /// </summary>
    protected char BorderChar
        => '\u25a0';
    /// <summary>
    /// Symbol for an unselected border
    /// </summary>
    protected virtual Symbol BorderUnselected
        => new Symbol(BorderChar, ConsoleColor.DarkBlue);
    /// <summary>
    /// Symbol for a selected border
    /// </summary>
    protected virtual Symbol BorderSelected 
        => new Symbol(BorderChar, ConsoleColor.Blue);
    /// <summary>
    /// Textbox title string
    /// </summary>
    protected string Title { get; }
    /// <summary>
    /// Textbox content/description string
    /// </summary>
    protected string Description { get; }
    
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="width">Width of the textbox, including border</param>
    /// <param name="height">Height of the textbox, including border</param>
    /// <param name="title">Title of the textbox</param>
    /// <param name="description">Content of the textbox</param>
    /// <param name="position">Position of the textbox</param>
    protected TextBox(int width, int height, string title, string description, Position position)
    {
        Width = width;
        Height = height;
        Title = title;
        Description = description;
        Position = position;
        //Calclate size of the content array from width and height.
        Content = new Symbol[Height, Width];
    }
    /// <summary>
    /// Drawing the textbox to a grid
    /// </summary>
    /// <param name="grid">SymbolGrid to draw to</param>
    /// <param name="isSelected">What border color to use, has other uses as well depending on subclass</param>
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

    /// <summary>
    /// Generating content for the textbox
    /// </summary>
    /// <param name="isSelected">Various uses</param>
    protected virtual void GenerateContent(bool isSelected)
    { }



}